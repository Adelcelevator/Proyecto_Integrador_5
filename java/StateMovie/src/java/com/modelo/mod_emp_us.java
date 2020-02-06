/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.modelo;

import com.objetos.ob_emp_us;
import com.vari.Variables;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import org.json.JSONArray;
import org.json.JSONObject;

/**
 *
 * @author Panchito
 */
public class mod_emp_us {
    ob_emp_us emple = new ob_emp_us();
    private final Variables vars = new Variables();

    /*public boolean registrar(ob_emp_us nuevo) {
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
    }*/
    public ob_emp_us ver(String usu) {
        try {
            String wer = "http://" + vars.getIp() + vars.getPuertp() + "/api/EmpleadoUs?emp_us=" + usu;
            URL url = new URL(wer);
            HttpURLConnection con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("GET");
            con.setRequestProperty("ACCEPT", "application/json");
            if (con.getResponseCode() == 200) {
                BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream()));
                String output;
                while ((output = br.readLine()) != null) {
                    JSONObject jsn = new JSONObject((output.replace("[", "")).replace("]", ""));
                    if(jsn.getInt("usu_id")!=0){
                        emple.setUsu_id(jsn.getInt("usu_id"));
                        emple.setTip_emp(jsn.getInt("tip_emp"));
                        emple.setCin_id(jsn.getInt("cin_id"));
                        emple.setEmp_id(jsn.getInt("emp_id"));
                        emple.setEmp_usu(jsn.getString("emp_usu"));
                        emple.setEmp_us_contra(jsn.getString("emp_us_contra"));
                        emple.setUsu_emp_est(jsn.getString("usu_emp_est"));
                    }else{
                        emple.setUsu_id(0);
                        emple.setTip_emp(0);
                        emple.setCin_id(0);
                        emple.setEmp_id(0);
                        emple.setEmp_usu("nada");
                        emple.setEmp_us_contra("nada");
                        emple.setUsu_emp_est("deleted");
                    }
                    }
                    return emple;
                }
                con.disconnect();
            
            return emple;
        } catch (IOException e) {
            System.out.println("ERROR AL TRAER EN EL MOD EMP_US: " + e);
            return emple;
        }
    }
}
