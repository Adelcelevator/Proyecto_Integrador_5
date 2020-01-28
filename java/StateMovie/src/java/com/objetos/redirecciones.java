/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.objetos;

import java.io.IOException;
import javax.faces.bean.ManagedBean;
import javax.faces.context.FacesContext;

/**
 *
 * @author Panchito
 */
@ManagedBean
public class redirecciones {
    FacesContext conte;
    
    public void redirlog(){
        try {
         conte=FacesContext.getCurrentInstance();
         conte.getExternalContext().redirect("/StateMovie/faces/login.xhtml");
        } catch (IOException e) {
            System.out.println("ERROR AL REDIRIGIR AL LOGIN: "+e);
        }
    }
}
