/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vari;

import java.io.Serializable;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

/**
 *
 * @author Panchito
 */
@ManagedBean(name = "redire")
@SessionScoped
public class redirecciones implements Serializable{

    FacesContext contes;

    public void redirAd() {
        try {
            contes = FacesContext.getCurrentInstance();
            contes.getExternalContext().redirect("Administrativo.xhtml");
        } catch (Exception e) {
            System.out.println("ERROR AL REDIRIGIR AL ADMINISTRATIVO: " + e);
        }
    }

    public void redirEm() {
        try {
            contes = FacesContext.getCurrentInstance();
            contes.getExternalContext().redirect("Empleados.xhtml");
        } catch (Exception e) {
            System.out.println("ERROR AL REDIRIGIR A EMPLEADOS: " + e);
        }
    }

    public void redirSuc() {
        try {
            contes = FacesContext.getCurrentInstance();
            contes.getExternalContext().redirect("Sucursales.xhtml");
        } catch (Exception e) {
            System.out.println("ERROR AL REDIRIGIR A LAS SUCURSALES: " + e);
        }
    }

    public void redirHo() {
        try {
            contes = FacesContext.getCurrentInstance();
            contes.getExternalContext().redirect("Horarios.xhtml");
        } catch (Exception e) {
            System.out.println("ERROR AL REDIRIGIR A HORARIOS: " + e);
        }
    }

    public void redirPe() {
        try {
            contes = FacesContext.getCurrentInstance();
            contes.getExternalContext().redirect("Peliculas.xhtml");
        } catch (Exception e) {
            System.out.println("ERROR AL REDIRIGIR A PELICULAS: " + e);
        }
    }
}
