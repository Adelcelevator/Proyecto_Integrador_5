/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.ob_ciudad;
import com.vari.Variables;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.Serializable;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import org.json.JSONArray;
import org.json.JSONObject;

/**
 *
 * @author Panchito
 */
public class mod_ciudad implements Serializable {

    ob_ciudad obciu = new ob_ciudad();
    List<ob_ciudad> lista = new ArrayList<ob_ciudad>();
    JSONObject obj = new JSONObject();
    JSONArray arrj =new JSONArray();
    Variables var = new Variables();
    String direc = "http://" + var.getIp() + var.getPuertp() + "/api/Ciudad";

    public List<ob_ciudad> todas() {
        lista.clear();
        try {
            URL url = new URL(direc);
            HttpURLConnection cone = (HttpURLConnection) url.openConnection();
            cone.setRequestMethod("GET");
            cone.setRequestProperty("ACCEPT", "application/json");
            if (cone.getResponseCode() == 200) {
                BufferedReader br = new BufferedReader(new InputStreamReader(cone.getInputStream()));
                String salida;
                while ((salida = br.readLine()) != null) {
                    arrj = new JSONArray(salida);
                    for(int i=0; i<arrj.length();i++){
                        obj = arrj.getJSONObject(i);
                        obciu.setCiu_id(obj.getInt("ciu_id"));
                        obciu.setCiu_nom(obj.getString("ciu_nom"));
                        obciu.setCiu_est(obj.getString("ciu_est"));
                        lista.add(obciu);
                    }

                }
            }
            return lista;
        } catch (Exception e) {
            System.out.println("ERROR AL TRAER TODAS LAS CIUDADES: " + e);
        }
        return lista;
    }
}
