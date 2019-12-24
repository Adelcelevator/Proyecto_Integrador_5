/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.objetos.usuario;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Serializable;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 *
 * @author Panchito
 */
@ManagedBean (name="index")
@SessionScoped
public class Index_controlador implements Serializable {

    private String usuario, contra, error;

    public String getError() {
        return error;
    }

    public void setError(String error) {
        this.error = error;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getContra() {
        return contra;
    }

    public void setContra(String contra) {
        this.contra = contra;
    }

    public Index_controlador() {
    }

    public void consumo() {

        System.out.println("=================================================================");
        System.out.println("=================================================================");
        System.out.println("=================================================================");
        System.out.println("=================================================================");
        System.out.println("=================================================================");
        System.out.println("=================================================================");
        try {
            final String urlweb = "http://localhost:51289/api/Usuario";
            URL url = new URL(urlweb);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("ACCEPT", "application/json");
            System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            if (conn.getResponseCode() == 200) {
                List<usuario> listus = new ArrayList<>();
                listus.clear();
                BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                String output;
                System.out.println("OUTPUT=++++++++++++++++++++++");
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
                    //usua.setUsu_id();
                    /*JSONObject json=new JSONObject((output.replace("]", "")).replace("[", ""));
                     */
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

        } catch (IOException | JSONException e) {
            System.out.println("=================================================================");
            System.out.println("ERROR: " + e);
        }
    }

    public void entrar() {
        String json;
        try {
            String urlweb = "http://localhost:51289/api/Usuario?usu_id=" + usuario;
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
                    error = "No Existe el usuario";
                } else {
                    if(obj.getString("usu_pass").equals(contra)){
                        FacesContext conte= FacesContext.getCurrentInstance();
                        conte.getExternalContext().redirect("login.xhtml");
                    }else{
                        error="Contraseña Incorrecta";
                    }
                }
            }
        } catch (Exception e) {
            System.out.println("ERROR AL INGRESAR: " + e);
        }
    }
}
