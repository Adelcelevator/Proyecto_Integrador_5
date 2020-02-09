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
            String werl = "http://" + vars.getIp() + vars.getPuertp() + "/api/Cliente?ruc=" + nuevo.getCli_ruc() + "&nom=" + nuevo.getCli_nom() + "&ape=" + nuevo.getCli_ape() + "&dire=" + nuevo.getCli_dire() + "&tel=" + nuevo.getCli_tel() + "&corr=" + nuevo.getCli_corr() + "&fnaci=" + nuevo.getCli_fnaci();
            URL url = new URL(werl);
            HttpURLConnection conex = (HttpURLConnection) url.openConnection();
            conex.setRequestMethod("POST");
            conex.setRequestProperty("Accept-Language", "en-US,en;q=0.5");
            conex.setFixedLengthStreamingMode(0);
            conex.setDoOutput(true);
            if (conex.getResponseCode() == 200) {
                System.out.println("ERROR: " + conex.getResponseMessage());
                return true;
            } else if (conex.getResponseCode() == 404) {
                System.out.println("ERROR: " + conex.getResponseMessage());
                return false;
            }
            System.out.println("ERROR: " + conex.getResponseMessage());
            return false;
        } catch (Exception e) {
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
                    JSONObject jsn = new JSONObject(output);
                        ob_cliente cli = new ob_cliente();
                        cli.setCli_id(jsn.getInt("cli_id"));
                        cli.setCli_ruc(jsn.getString("cli_ruc"));
                        cli.setCli_nom(jsn.getString("cli_nom"));
                        cli.setCli_ape(jsn.getString("cli_ape"));
                        cli.setCli_dire(jsn.getString("cli_dire"));
                        cli.setCli_tel(jsn.getString("cli_tel"));
                        cli.setCli_corr(jsn.getString("cli_corr"));
                        cli.setCli_fnaci(jsn.getString("cli_fnaci"));
                        cli.setCli_est(jsn.getString("cli_est"));
                    return cli;
                }
                con.disconnect();
            }
            return clie;
        } catch (Exception e) {
            System.out.println("ERROR AL TRAER EN EL MOD: " + e);
            return clie;
        }
    }
}
