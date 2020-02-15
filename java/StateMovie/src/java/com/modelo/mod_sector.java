/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.ob_sector;
import com.vari.Variables;
import java.io.BufferedReader;
import java.io.InputStreamReader;
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
public class mod_sector {
    private ob_sector obsec = new ob_sector();
    private Variables var = new Variables();
    private String dire = "http://"+var.getIp()+var.getPuertp()+"/api/Sector";
    private List<ob_sector> lista = new ArrayList<>();
    
    public List<ob_sector> todosS(){
        lista.clear();
        try{
            URL url = new URL(dire);
            HttpURLConnection cone = (HttpURLConnection) url.openConnection();
            cone.setRequestMethod("GET");
            cone.setRequestProperty("ACCEPT", "application/json");
            BufferedReader br = new BufferedReader(new InputStreamReader(cone.getInputStream()));
            String sal;
            while((sal=br.readLine())!= null){
                JSONArray arj = new JSONArray(sal);
                JSONObject obj;
                for(int i =0; i<arj.length();i++){
                    obj = arj.getJSONObject(i);
                    obsec.setSec_id(obj.getInt("sec_id"));
                    obsec.setCiu_id(obj.getInt("ciu_id"));
                    obsec.setSec_nom(obj.getString("sec_nom"));
                    obsec.setSec_est(obj.getString("sec_est"));
                    lista.add(obsec);
                }
            }
            return lista;
        }catch(Exception e){
            System.out.println("ERROR AL TRAER SECTORES: "+e);
        }
        return lista;
    }
}
