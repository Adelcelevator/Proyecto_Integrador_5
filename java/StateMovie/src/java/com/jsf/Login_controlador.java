/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.objetos.usuario;
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
@ManagedBean (name="login")
@SessionScoped
public class Login_controlador implements Serializable{
    public List<usuario> mostarlista(){
        try{
        List<usuario> lista=new ArrayList<>();
        lista.clear();
        try {
            FacesContext conte=FacesContext.getCurrentInstance();
            lista = (List<usuario>) conte.getExternalContext().getSessionMap().get("lista");
            System.out.println("===================================================");
            System.out.println("Lista: "+ lista.size());
            System.out.println("Lista: "+ lista.get(0).getUsu_usu());
            System.out.println("Lista: "+ lista.get(1).getUsu_usu());
            System.out.println("Lista: "+ lista.get(2).getUsu_usu());
            System.out.println("===================================================");
            return lista;
        } catch (Exception e) {
            System.out.println("ERROR AL TRAER LA LISTA: "+e);
        }
        return lista;
        }catch(Exception e){
            System.out.println("ERROR ASA "+e);
        }
        return null;
    }
}
