/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.ob_cliente;
import com.objetos.ob_usuario;
import com.vari.Variables;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Serializable;
import java.net.HttpURLConnection;
import java.net.URL;
import org.json.JSONArray;
import org.json.JSONObject;

/**
 *
 * @author Panchito
 */
public class mod_cliente implements Serializable {

    ob_cliente clie = new ob_cliente();
    private final Variables vars = new Variables();

    public boolean registrar(ob_cliente nuevo) {
        try {
            String werl = "http://" + vars.getIp() + vars.getPuertp() + "/api/Cliente?ruc=" + nuevo.getCli_ruc() + "&nom=" + nuevo.getCli_nom() + "&ape=" + nuevo.getCli_ape() + "&dire=" + nuevo.getCli_dire() + "&tel=" + nuevo.getCli_tel() + "&corr=" + nuevo.getCli_corr() + "&fnaci=" + nuevo.getCli_fnaci() + "&est=activo";
            System.out.println("SALIDA DEL NUEOV CLI: " + werl);
            URL url = new URL(werl);
            HttpURLConnection conex = (HttpURLConnection) url.openConnection();
            conex.setRequestMethod("POST");
            conex.setRequestProperty("ACCEPT", "application/json");
            if (conex.getResponseCode() == 200) {
                return true;
            } else {
                return false;
            }
        } catch (IOException e) {
            System.out.println("ERROR AL REGISTRAR EN EL MOD: " + e);
            return false;
        }
    }

    public ob_cliente ver(String ci) {
        try {
            String wer = "http://" + vars.getIp() + vars.getPuertp() + "/api/Cliente?ruc=" + ci;
            URL url = new URL(wer);
            HttpURLConnection con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("GET");
            con.setRequestProperty("ACCEPT", "application/json");
            if (con.getResponseCode() == 200) {
                BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream()));
                String output;
                while ((output = br.readLine()) != null) {
                    System.out.println(output);
                    JSONArray json = new JSONArray(output);
                    System.out.println("TAMA: " + json.length());
                    for (int i = 0; i < json.length(); i++) {
                        ob_usuario usua = new ob_usuario();
                        JSONObject jsn = json.getJSONObject(i);
                        usua.setUsu_id(jsn.getInt("usu_id"));
                        usua.setCli_id(jsn.getInt("cli_id"));
                        usua.setTus_id(jsn.getInt("tus_id"));
                        usua.setUsu_usu(jsn.getString("usu_usu"));
                        usua.setUsu_pass(jsn.getString("usu_pass"));
                    }
                    return clie;
                }
                con.disconnect();
            }
            return clie;
        } catch (IOException e) {
            System.out.println("ERROR AL TRAER EN EL MOD: " + e);
            return clie;
        }
    }
}
