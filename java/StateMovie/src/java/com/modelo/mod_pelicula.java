/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.ob_pelicula;
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
public class mod_pelicula implements Serializable {

    ob_pelicula pel = new ob_pelicula();
    Variables var = new Variables();
    List<ob_pelicula> lispe = new ArrayList<>();

    public List<ob_pelicula> todas_pel() {
        lispe.clear();
        try {
            String wurl = "http://" + var.getIp() + var.getPuertp() + "/api/Pelicula";
            URL url = new URL(wurl);
            HttpURLConnection con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("GET");
            con.setRequestProperty("ACCEPT", "application/json");
            if (con.getResponseCode() == 200) {
                lispe.clear();
                BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream()));
                JSONArray arr = new JSONArray(br.readLine());
                for (int i = 0; i < arr.length(); i++) {
                    ob_pelicula peli = new ob_pelicula();
                    JSONObject obj = new JSONObject(arr.get(i));
                    peli.setPel_id(obj.getInt("pel_id"));
                    peli.setPel_dire(obj.getString("pel_dire"));
                    peli.setPel_nom(obj.getString("pel_nom"));
                    peli.setPel_pro(obj.getString("pel_pro"));
                    peli.setPel_cla(obj.getString("pel_cla"));
                    peli.setPel_est(obj.getString("pel_est"));
                    peli.setPel_linkv(obj.getString("pel_linkv"));
                    peli.setPel_linkba(obj.getString("pel_linkba"));
                    lispe.add(peli);
                }
                return lispe;
            }
        } catch (IOException | JSONException e) {
            System.out.println("ERROR AL LEER TODAS LAS PELICULAS: " + e);
        }
        return lispe;
    }

    public List<ob_pelicula> busca(String nomp) {
        lispe.clear();
        try {
            String wurl = "http://" + var.getIp() + var.getPuertp() + "/api/Pelicula?pel_id=%25" + nomp + "%25";
            URL url = new URL(wurl);
            HttpURLConnection con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("GET");
            con.setRequestProperty("ACCEPT", "application/json");
            if (con.getResponseCode() == 200) {
                lispe.clear();
                BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream()));
                String salida;
                while ((salida = br.readLine()) != null) {
                    System.out.println("SALIDA: "+salida);
                    JSONArray arr = new JSONArray(salida);
                    System.out.println("# DE OBJETOS: "+arr.length());
                    for (int i = 0; i < arr.length(); i++) {
                        ob_pelicula peli = new ob_pelicula();
                        JSONObject obj = arr.getJSONObject(i);
                        peli.setPel_id(obj.getInt("pel_id"));
                        peli.setPel_dire(obj.getString("pel_dire"));
                        peli.setPel_nom(obj.getString("pel_nom"));
                        peli.setPel_pro(obj.getString("pel_pro"));
                        peli.setPel_cla(obj.getString("pel_cla"));
                        peli.setPel_est(obj.getString("pel_est"));
                        peli.setPel_linkv(obj.getString("pel_linkv"));
                        peli.setPel_linkba(obj.getString("pel_linkba"));
                        lispe.add(peli);
                    }
                }
                return lispe;
            }
        } catch (IOException | JSONException e) {
            System.out.println("ERROR AL LEER TODAS LAS PELICULAS: " + e);
        }
        return lispe;
    }
}
