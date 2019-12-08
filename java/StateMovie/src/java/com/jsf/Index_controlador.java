/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.objetos.usuario;
import java.io.BufferedReader;
import java.io.IOException;
import org.json.JSONObject;
import java.io.InputStreamReader;
import java.io.Serializable;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

/**
 *
 * @author Panchito
 */
@ManagedBean(name = "index")
@SessionScoped
public class Index_controlador implements Serializable {

    public void consumo() {

        System.out.println("=================================================================");
        System.out.println("=================================================================");
        System.out.println("=================================================================");
        System.out.println("=================================================================");
        System.out.println("=================================================================");
        System.out.println("=================================================================");
        try {
            final String urlweb = "localhost:51289/api/Usuario";
            URL url = new URL(urlweb);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("ACCEPT", "application/json");
            System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            if (conn.getResponseCode() == 200) {
                List<usuario> listus=new ArrayList<>();
                listus.clear();
                BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                String output;
                System.out.println("OUTPUT=++++++++++++++++++++++");
                while ((output = br.readLine()) != null) {
                    System.out.println(output);
                    JSONObject json=new JSONObject(output);
                    usuario us=new usuario();
                    us.setUsu_id(json.getInt("usu_id"));
                    us.setCli_id(json.getInt("cli_id"));
                    us.setTus_id(json.getInt("tus_id"));
                    us.setUsu_usu(json.getString("usu_usu"));
                    us.setUsu_pass(json.getString("usu_pass"));
                    listus.add(us);
                }
                conn.disconnect();
                FacesContext con = FacesContext.getCurrentInstance();
                con.getExternalContext().redirect("login.xhtml");
                con.getExternalContext().getSessionMap().put("lista", listus);
                /*
                ====================================================================================
                para guardar variables de sesion se hace asi
                FacesContext con= FacesContext.getCurrentInstance();
                con.getExternalContext().getSessionMap().put(nombre_cualquiera, valor_a_guardar);
                ====================================================================================
                para leer variables de sesion se hace asi
                FacesContext con= FacesContext.getCurrentInstance();
                nombre_de_variable = (casteo_de_lo_que_quiero) con.getExternalContext().getSessionMap().get("el_nombre_con_el_que_guarde");
                
                 */
            }

        } catch (Exception e) {
            System.out.println("=================================================================");
            System.out.println("ERROR: " + e);
        }
    }
}
