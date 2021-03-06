/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.modelo.mod_cliente;
import com.modelo.mod_emp_us;
import com.modelo.mod_usuario;
import com.objetos.ob_cliente;
import com.objetos.ob_emp_us;
import com.objetos.ob_usuario;
import com.vari.Variables;
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
public class Login_controlador implements Serializable{

    private Variables vari = new Variables();
    private final mod_emp_us memple = new mod_emp_us();
    private final mod_usuario usu = new mod_usuario();
    private ob_usuario us;
    private ob_emp_us emp;
    mod_cliente clie = new mod_cliente();
    ob_cliente ncliente = new ob_cliente();
    FacesContext conte;
    String ci, nom, ape, dire, tele, corr, logusuario, logcontra, nusuario, ncontra, nconf;
    boolean rende = false;
    public Date fenaci;
    private Date fechahoy = new Date();

    public Login_controlador() {
    }

    public void prueba_de_reg() {
        try {
            conte = FacesContext.getCurrentInstance();
            conte.getExternalContext().redirect("Protegidos/Administracion/Administrativo.xhtml");
        } catch (Exception e) {
            System.out.println("ERROR AL REDIRIGIR: " + e);
        }
    }

    public void entrar() {
        try {
            if (!"".equals(logusuario) && !"".equals(logcontra)) {
                us = usu.entrar(logusuario);
                if (us.getUsu_id() != 0) {
                    if (us.getUsu_pass().equals(logcontra)) {
                        conte = FacesContext.getCurrentInstance();
                        conte.getExternalContext().getSessionMap().put("usuario", us);
                        conte.getExternalContext().redirect("Protegidos/pagina2.xhtml");
                    } else {
                        conte = FacesContext.getCurrentInstance();
                        conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_ERROR, "Info", "Contraseña Incorrecta"));
                    }
                } else {
                    emp = memple.ver(logusuario);
                    if (emp.getUsu_id() != 0 && emp.getEmp_id() != 0) {
                        if (emp.getEmp_us_contra().equals(logcontra)) {
                            conte = FacesContext.getCurrentInstance();
                            conte.getExternalContext().getSessionMap().put("empleado", emp);
                            conte.getExternalContext().redirect("Protegidos/Administracion/Administrativo.xhtml");
                        } else {
                            conte = FacesContext.getCurrentInstance();
                            conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "Info", "Contraseña Incorrecta"));
                        }

                    } else {
                        conte = FacesContext.getCurrentInstance();
                        conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "Info", "No Existe el Usuario"));
                    }
                }
            } else {
                conte = FacesContext.getCurrentInstance();
                conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "Info", "Campos Vacios"));
            }
        } catch (Exception e) {
            System.out.println("ERROR AL ENTRAR:" + e);
        }
    }

    public void registrar() {
        try {
            us = usu.entrar(nusuario);
            ncliente = clie.ver(ci);
            if (us.getUsu_id() != 0 && ncliente.getCli_id() != 0) {
                conte = FacesContext.getCurrentInstance();
                conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_ERROR, "ERROR", "Usuario y Cliente ya registrado"));
            } else {
                if (ape.equals("") && corr.equals("") && dire.equals("") && nom.equals("") && ci.equals("") && tele.equals("")) {
                    conte = FacesContext.getCurrentInstance();
                    conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "Información", "Campos Vacios"));
                } else {
                    ob_cliente nuevo = new ob_cliente();
                    nuevo.setCli_ape(ape);
                    nuevo.setCli_corr(corr);
                    nuevo.setCli_dire(dire);
                    nuevo.setCli_fnaci(vari.converFech(fenaci).replace("/", "%2F"));
                    nuevo.setCli_nom(nom);
                    nuevo.setCli_ruc(ci);
                    nuevo.setCli_tel(tele);
                    if (clie.registrar(nuevo)) {
                        ncliente = clie.ver(ci);
                        us.setUsu_id(0);
                        us.setCli_id(ncliente.getCli_id());
                        us.setUsu_pass(ncontra);
                        us.setUsu_usu(nusuario);
                        if (usu.registrar(us)) {
                            conte = FacesContext.getCurrentInstance();
                            conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "INFO", "Usuario Registrado con Exito"));
                        } else {
                            conte = FacesContext.getCurrentInstance();
                            conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_FATAL, "INFO", "Error al Registrar el Usuario"));
                        }
                    } else {
                        conte = FacesContext.getCurrentInstance();
                        conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "INFO", "Error al registrar el cliente"));
                    }
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
