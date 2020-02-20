/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.ob_sucursal;
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
public class mod_sucursal implements Serializable{

    public List<ob_sucursal> liss = new ArrayList<ob_sucursal>();
    public ob_sucursal sucs;
    private Variables vars = new Variables();
    String wsr = "http://" + vars.getIp() + vars.getPuertp() + "/api/Sucursal";

    public List<ob_sucursal> tods() {
        try {
            liss.clear();
            URL wer = new URL(wsr);
            HttpURLConnection conx = (HttpURLConnection) wer.openConnection();
            conx.setRequestMethod("GET");
            conx.setRequestProperty("ACCEPT", "application/json");
            if (conx.getResponseCode() == 200) {
                BufferedReader bf = new BufferedReader(new InputStreamReader(conx.getInputStream()));
                String fue;
                while ((fue = bf.readLine()) != null) {
                    JSONArray arg = new JSONArray(fue);
                    for (int i = 0; i < arg.length(); i++) {
                        sucs = new ob_sucursal();
                        JSONObject nuevo = arg.getJSONObject(i);
                        sucs.setSec_id(nuevo.getInt("sec_id"));
                        sucs.setCin_id(nuevo.getInt("cin_id"));
                        sucs.setCiu_id(nuevo.getInt("ciu_id"));
                        sucs.setSuc_id(nuevo.getInt("suc_id"));
                        sucs.setSuc_nom(nuevo.getString("suc_nom"));
                        sucs.setSuc_ruc(nuevo.getString("suc_ruc"));
                        sucs.setSuc_tel(nuevo.getString("suc_tel"));
                        sucs.setSuc_cor(nuevo.getString("suc_cor"));
                        sucs.setSuc_dir(nuevo.getString("suc_dir"));
                        sucs.setSuc_esta(nuevo.getString("suc_esta"));
                        liss.add(sucs);
                    }
                }
                return liss;
            }else{
            liss.clear();
            return liss;
            }
        } catch (Exception e) {
            System.out.println("ERROR EN SUCURSALES: " + e);
            liss.clear();
            return liss;
        }
    }
    
    

    public boolean guardar(ob_sucursal bosuc){
        try{
           //aqui adentro
           wsr = wsr+"?cin_id="+bosuc.getCin_id()+"&ciu_id="+bosuc.getCiu_id()+"&sec_id="+bosuc.getSec_id()+"&suc_nom="+bosuc.getSuc_nom()+"&suc_ruc="+bosuc.getSuc_ruc()+"&suc_dir="+bosuc.getSuc_dir()+"&suc_tel="+bosuc.getSuc_tel()+"&suc_cor="+bosuc.getSuc_cor();
            //System.out.println("SALIDA: "+werl);
            URL url = new URL(wsr);
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
        }catch(Exception e){
            System.out.println("ERROR AL GUARDAR LA SUCURSAL: "+e);
        }
        
        return  false;
    }
}
