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
@ManagedBean
@SessionScoped
public class Login_controlador implements Serializable{
    public usuario mostarlista(){
        List<usuario> lista=new ArrayList<>();
        lista.clear();
        try {
            FacesContext conte=FacesContext.getCurrentInstance();
            lista = (List<usuario>) conte.getExternalContext().getSessionMap().get("lista");
            System.out.println("===================================================");
            System.out.println("Lista: "+ lista.toString());
            System.out.println("===================================================");
            return (usuario) lista;
        } catch (Exception e) {
            System.out.println("ERROR AL TRAER LA LISTA: "+e);
        }
        return (usuario) lista;
    }
}
