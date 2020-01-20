/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.objetos.pelicula;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

/**
 *
 * @author Panchito
 */
@ManagedBean(name = "pelis")
@SessionScoped
public class Pelicula_controlador implements Serializable{
    public String termi;

    public String getTermi() {
        return termi;
    }

    public void setTermi(String termi) {
        this.termi = termi;
    }
    
    public List<pelicula> pelis= new ArrayList<>();
    FacesContext conte= FacesContext.getCurrentInstance();
    public List<pelicula> resulBus(){
        try{
            pelis = (List<pelicula>) conte.getExternalContext().getSessionMap().get("lista_peli");
            return pelis;
        }catch(Exception e){
            System.out.println("ERROR AL BUSCAR EN LA PAG 2: "+e);
        }
        pelis.clear();
        return  pelis;
    }
    
    public String termi(){
        termi = (String) conte.getExternalContext().getSessionMap().get("termi");
        return termi;
    }
}
