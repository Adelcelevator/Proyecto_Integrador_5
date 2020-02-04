/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.modelo.mod_cliente;
import com.modelo.mod_usuario;
import com.objetos.ob_cliente;
import com.objetos.ob_usuario;
import java.io.IOException;
import java.io.Serializable;
import java.util.Date;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

/**
 *
 * @author Panchito
 */
@ManagedBean(name = "login")
@SessionScoped
public class Login_controlador implements Serializable {

    private mod_usuario usu = new mod_usuario();
    private ob_usuario us;
    FacesContext conte;
    String ci, nom, ape, dire, tele, corr, logusuario, logcontra, nusuario, ncontra, nconf;
    boolean rende = false;
    public Date fenaci;
    private Date fechahoy = new Date();

    public Login_controlador() {
    }

    public void entrar() {
        try {
            if (!"".equals(logusuario) && !"".equals(logcontra)) {
                us = usu.entrar(logusuario);
                if (us.getUsu_id() != 0) {
                    if (us.getUsu_pass().equals(logcontra)) {
                        FacesContext context = FacesContext.getCurrentInstance();
                        context.getExternalContext().getSessionMap().put("usuario", us);
                        context.getExternalContext().redirect("Protegidos/pagina2.xhtml");
                    } else {
                        conte = FacesContext.getCurrentInstance();
                        conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_ERROR, "Error:", "Contraseña Incorrecta"));
                    }
                } else {
                    conte = FacesContext.getCurrentInstance();
                    conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_ERROR, "Error:", "No Existe el Usuario"));
                }
            } else {
                conte = FacesContext.getCurrentInstance();
                conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "Información", "Campos Vacios"));
            }
        } catch (IOException e) {
            System.out.println("ERROR AL ENTRAR:" + e);
        }
    }

    public void registrar() {
        try {
            us = usu.entrar(nusuario);
            if (us.getUsu_id() != 0) {
                conte = FacesContext.getCurrentInstance();
                conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_ERROR, "ERROR", "Usuario ya registrado"));
            } else {
                if (ape.equals("") && corr.equals("") && dire.equals("") && nom.equals("") && ci.equals("") && tele.equals("")) {
                    conte = FacesContext.getCurrentInstance();
                    conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "Información", "Campos Vacios"));
                }else{
                    mod_cliente clie = new mod_cliente();
                    ob_cliente nuevo = new ob_cliente();
                    nuevo.setCli_ape(ape);
                    nuevo.setCli_corr(corr);
                    nuevo.setCli_dire(dire);
                    nuevo.setCli_fnaci(fenaci.toString());
                    nuevo.setCli_nom(nom);
                    nuevo.setCli_ruc(ci);
                    nuevo.setCli_tel(tele);
                    clie.registrar(nuevo);
                    
                }
            }
        } catch (Exception e) {
            System.out.println("REGISTRAR: " + e);
        }
    }

    public String getLogusuario() {
        return logusuario;
    }

    public void setLogusuario(String logusuario) {
        this.logusuario = logusuario;
    }

    public String getLogcontra() {
        return logcontra;
    }

    public void setLogcontra(String logcontra) {
        this.logcontra = logcontra;
    }

    public String getNusuario() {
        return nusuario;
    }

    public void setNusuario(String nusuario) {
        this.nusuario = nusuario;
    }

    public String getNcontra() {
        return ncontra;
    }

    public void setNcontra(String ncontra) {
        this.ncontra = ncontra;
    }

    public String getNconf() {
        return nconf;
    }

    public void setNconf(String nconf) {
        this.nconf = nconf;
    }

    public boolean isRende() {
        return rende;
    }

    public void setRende(boolean rende) {
        this.rende = rende;
    }

    public Date getFenaci() {
        return fenaci;
    }

    public void setFenaci(Date fenaci) {
        this.fenaci = fenaci;
    }

    public Date getFechahoy() {
        return fechahoy;
    }

    public void setFechahoy(Date fechahoy) {
        this.fechahoy = fechahoy;
    }

    public String getCi() {
        return ci;
    }

    public void setCi(String ci) {
        this.ci = ci;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getApe() {
        return ape;
    }

    public void setApe(String ape) {
        this.ape = ape;
    }

    public String getDire() {
        return dire;
    }

    public void setDire(String dire) {
        this.dire = dire;
    }

    public String getTele() {
        return tele;
    }

    public void setTele(String tele) {
        this.tele = tele;
    }

    public String getCorr() {
        return corr;
    }

    public void setCorr(String corr) {
        this.corr = corr;
    }

}
