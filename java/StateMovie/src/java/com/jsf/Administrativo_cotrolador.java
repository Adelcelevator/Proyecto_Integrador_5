/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.modelo.mod_cine;
import com.objetos.ob_cine;
import com.objetos.ob_emp_us;
import java.io.IOException;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

/**
 *
 * @author Panchito
 */
@ManagedBean(name = "adminip1")
@SessionScoped
public class Administrativo_cotrolador implements Serializable {

    private String nueva;
    private ob_cine cine = new ob_cine();
    private mod_cine mci = new mod_cine();
    private ob_emp_us emp_us = new ob_emp_us();
    private List<ob_cine> lis = new ArrayList<>();
    private FacesContext conte;

    public List<ob_cine> todos() {
        lis = mci.todosc();
        return lis;
    }

    public String usua() {
        String dsa = "";
        try {
            conte = FacesContext.getCurrentInstance();
            emp_us = (ob_emp_us) conte.getExternalContext().getSessionMap().get("empleado");
            if (emp_us != null) {
                dsa = emp_us.getEmp_usu();
                System.out.println("SALIDA DEL OTRO LADO: " + dsa);
                return dsa;
            } else {
                conte = FacesContext.getCurrentInstance();
                conte.getExternalContext().redirect("../../index.xhtml");
            }
        } catch (Exception e) {
            try{
            conte = FacesContext.getCurrentInstance();
            conte.getExternalContext().redirect("../../index.xhtml");
            System.out.println("ERROR: " + e);
            }catch(IOException ex){
                System.out.println("JAJAJAJAJA: "+ex);
            }
            return dsa;
        }
        return dsa;
    }

    public void cerrar() {
        try {
            conte = FacesContext.getCurrentInstance();
            conte.getExternalContext().getSessionMap().clear();
            conte.getExternalContext().redirect("../../index.xhtml");
        } catch (Exception e) {
            System.out.println("ERROR: " + e);
        }
    }

    public void nuevaCasa() {
        if (mci.nuev(nueva) == true) {
            conte = FacesContext.getCurrentInstance();
            conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "INFO", "La casa de cine " + nueva + " a sido registrada con exito"));
        } else {
            conte = FacesContext.getCurrentInstance();
            conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "INFO", "Error al Registrar"));
        }
    }

    public String getNueva() {
        return nueva;
    }

    public void setNueva(String nueva) {
        this.nueva = nueva;
    }
}
