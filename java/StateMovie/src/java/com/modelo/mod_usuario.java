/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.usuario;
import com.vari.Variables;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Serializable;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 *
 * @author Panchito
 */
public class mod_usuario implements Serializable{

    usuario us = new usuario();
    Variables var = new Variables();
    List<usuario> listus = new ArrayList<>();

    public List<usuario> todos_usu() {
        listus.clear();
        try {
            final String urlweb = "http://" + var.getIp() + var.getPuertp() + "/api/Usuario";
            URL url = new URL(urlweb);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("ACCEPT", "application/json");
            if (conn.getResponseCode() == 200) {
                listus.clear();
                BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                String output;
                while ((output = br.readLine()) != null) {
                    System.out.println(output);
                    System.out.println("tama: " + output.length());
                    JSONArray json = new JSONArray(output);
                    System.out.println("TAMA: " + json.length());
                    for (int i = 0; i < json.length(); i++) {
                        usuario usua = new usuario();
                        JSONObject jsn = json.getJSONObject(i);
                        usua.setUsu_id(jsn.getInt("usu_id"));
                        usua.setCli_id(jsn.getInt("cli_id"));
                        usua.setTus_id(jsn.getInt("tus_id"));
                        usua.setUsu_usu(jsn.getString("usu_usu"));
                        usua.setUsu_pass(jsn.getString("usu_pass"));
                        listus.add(usua);
                        System.out.println("Tama lista: " + listus.size());
                    }
                    return listus;
                }
                conn.disconnect();
            }
        } catch (IOException | JSONException e) {
            System.out.println("ERROR " + e);
        }
        return listus;
    }

    public usuario entrar(String usuario) {
        String json;
        try {
            String urlweb = "http://" +var.getIp()+var.getPuertp()+"/api/Usuario?usu_id =" + usuario;
            URL url = new URL(urlweb);
            HttpURLConnection conec = (HttpURLConnection) url.openConnection();
            conec.setRequestMethod("GET");
            conec.setRequestProperty("ACCEPT", "application/json");
            if (conec.getResponseCode() == 200) {
                BufferedReader br = new BufferedReader(new InputStreamReader(conec.getInputStream()));
                json = br.readLine();
                JSONObject obj = new JSONObject((json.replace("[", "")).replace("]", ""));
                conec.disconnect();
                if (obj.getInt("cli_id") == 0) {
                    us.setCli_id(0);
                    us.setTus_id(0);
                    us.setUsu_id(0);
                    us.setUsu_pass("NO");
                    us.setUsu_usu("NEGADO");
                } else {
                    us.setCli_id(obj.getInt(""));
                }
            }
        } catch (IOException | JSONException e) {
            System.out.println("ERROR AL INGRESAR: " + e);
        }
        return us;
    }
}
