/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.ob_cine;
import com.vari.Variables;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
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
public class mod_cine {

    private List<ob_cine> lista = new ArrayList<>();
    private ob_cine cin = new ob_cine();
    private Variables vari = new Variables();
    String werl = "http://" + vari.getIp() + vari.getPuertp() + "/api/Cine";

    public List<ob_cine> todosc() {
        lista.clear();
        try {
            URL url = new URL(werl);
            HttpURLConnection con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("GET");
            con.setRequestProperty("ACCEPT", "application/json");
            if (con.getResponseCode() == 200) {
                BufferedReader brf = new BufferedReader(new InputStreamReader(con.getInputStream()));
                String sali;
                while ((sali = brf.readLine()) != null) {
                    JSONArray arr = new JSONArray(sali);
                    for (int i = 0; i < arr.length(); i++) {
                        ob_cine nuevo = new ob_cine();
                        JSONObject obj = arr.getJSONObject(i);
                        nuevo.setCin_id(obj.getInt("cin_id"));
                        nuevo.setCin_nom(obj.getString("cin_nom"));
                        nuevo.setCin_est(obj.getString("cin_est"));
                        lista.add(nuevo);
                    }
                }
                con.disconnect();
                return lista;
            }
        } catch (IOException | JSONException e) {
            System.out.println("ERROR AL TRAER LOS CINES: " + e);
            lista.clear();
            return lista;
        }
        lista.clear();
        return lista;
    }

    public boolean nuev(String nom) {
        try {
            werl = werl+"?nom=" + nom;
            //System.out.println("SALIDA: "+werl);
            URL url = new URL(werl);
            HttpURLConnection con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("POST");
            con.setRequestProperty("Accept-Language", "en-US,en;q=0.5");
            con.setFixedLengthStreamingMode(0);
            con.setDoOutput(true);
            if (con.getResponseCode() == 200) {
                //System.out.println("ERROR: " + con.getResponseMessage());
                return true;
            } else if (con.getResponseCode() == 404) {
              //  System.out.println("ERROR: " + con.getResponseMessage());
               // System.out.println("YO QUE SE:" + con.getResponseMessage());
                return false;
            }
            //System.out.println("YO QUE SE:" + con.getResponseMessage());
            return false;
        } catch (Exception e) {
            System.out.println("ERROR AL GUARDAR CASA DE CINE: " + e);
            return false;
        }
    }
    
    public ob_cine cinebus(String nombre) {
        try {
            werl = werl + "?nombre=" + nombre.replace(" ", "%20");
            URL url = new URL(werl);
            HttpURLConnection cone = (HttpURLConnection) url.openConnection();
            cone.setRequestMethod("GET");
            cone.setRequestProperty("ACCEPT", "application/json");
            BufferedReader br = new BufferedReader(new InputStreamReader(cone.getInputStream()));
            String out = br.readLine();
            if (out != null) {
                JSONObject jsn = new JSONObject(out);
                cin.setCin_id(jsn.getInt("cin_id"));
                cin.setCin_nom(jsn.getString("cin_nom"));
                cin.setCin_est(jsn.getString("cin_est"));
                return cin;
            } else {
                return cin;
            }
        } catch (Exception e) {
            System.out.println("ERROR AL TRAER EL CINE: "+e);
        }
        return cin;
    }
}
