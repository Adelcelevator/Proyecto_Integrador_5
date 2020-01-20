/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.modelo.mod_pelicula;
import com.objetos.pelicula;
import java.io.IOException;
import java.io.Serializable;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import org.json.JSONException;

/**
 *
 * @author Panchito
 */
@ManagedBean (name="index")
@SessionScoped
public class Index_controlador implements Serializable {

    private String usuario, contra, error, nomp;

    public String getNomp() {
        return nomp;
    }

    public void setNomp(String nomp) {
        this.nomp = nomp;
    }
    
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
        try{
                FacesContext con = FacesContext.getCurrentInstance();
                con.getExternalContext().redirect("login.xhtml");
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

        } catch (IOException | JSONException e) {
            System.out.println("=================================================================");
            System.out.println("ERROR: " + e);
        }
    }

    public void entrar() {
        
    }
    public void inicio(){
        try{
        FacesContext cont=FacesContext.getCurrentInstance();
        cont.getExternalContext().redirect("index.xhtml");
        }catch(IOException e){
            System.out.println("ERROR AL REDIRIGIR: "+e);
        }
    }
    public void buscar(){
        try{
            FacesContext conte= FacesContext.getCurrentInstance();
            List<pelicula> lis;
            mod_pelicula obp= new mod_pelicula();
            lis =obp.busca(nomp);
            conte.getExternalContext().getSessionMap().put("termi",nomp);
            conte.getExternalContext().getSessionMap().put("lista_peli", lis);
            conte.getExternalContext().redirect("peliculas.xhtml");
        }catch(Exception e){
            System.out.println("ERROR AL BUSCAR: "+e);
        }
    }
}
