/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.modelo.mod_cine;
import com.modelo.mod_ciudad;
import com.modelo.mod_sector;
import com.modelo.mod_sucursal;
import com.objetos.ob_cine;
import com.objetos.ob_ciudad;
import com.objetos.ob_sector;
import com.objetos.ob_sucursal;
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
@ManagedBean(name = "sucursal")
@SessionScoped
public class Sucursales_controlador implements Serializable {
    private FacesContext conte;
    private String nsuci, nnsuc, nrucsuc, ntelsuc, ncorr, nsucdir, nsuctel, nsucciu, nsucsec;
    private List<ob_sucursal> lis = new ArrayList<>();
    private mod_sucursal ms = new mod_sucursal();
    private ob_sucursal obsuc = new ob_sucursal();
    private mod_sector secto = new mod_sector();
    private mod_ciudad ciu = new mod_ciudad();
    private ob_sector sec = new ob_sector();
    private ob_ciudad ciud = new ob_ciudad();
    private mod_cine mci = new mod_cine();
    private ob_cine nomci = new ob_cine();

    public String getNsucsec() {
        return nsucsec;
    }

    public void setNsucsec(String nsucsec) {
        this.nsucsec = nsucsec;
    }

    public String getNsuctel() {
        return nsuctel;
    }

    public void setNsuctel(String nsuctel) {
        this.nsuctel = nsuctel;
    }

    public String getNsucdir() {
        return nsucdir;
    }

    public void setNsucdir(String nsucdir) {
        this.nsucdir = nsucdir;
    }

    public String getNsuci() {
        return nsuci;
    }

    public void setNsuci(String nsuci) {
        this.nsuci = nsuci;
    }

    public String getNnsuc() {
        return nnsuc;
    }

    public void setNnsuc(String nnsuc) {
        this.nnsuc = nnsuc;
    }

    public String getNrucsuc() {
        return nrucsuc;
    }

    public void setNrucsuc(String nrucsuc) {
        this.nrucsuc = nrucsuc;
    }

    public String getNtelsuc() {
        return ntelsuc;
    }

    public void setNtelsuc(String ntelsuc) {
        this.ntelsuc = ntelsuc;
    }

    public String getNcorr() {
        return ncorr;
    }

    public void setNcorr(String ncorr) {
        this.ncorr = ncorr;
    }

    public String getNsucciu() {
        return nsucciu;
    }

    public void setNsucciu(String nsucci) {
        this.nsucciu = nsucci;
    }

    public Sucursales_controlador() {
    }

    public List<ob_sucursal> todo() {
        try {
            lis.clear();
            lis = ms.tods();
            return lis;
        } catch (Exception e) {
            System.out.println("Error Al Traer las Sucursales: " + e);
            lis.clear();
            return lis;
        }
    }

    public List<String> todos() {
        List<String> nomC = new ArrayList<>();
        try {
            nomC.clear();

            List<ob_cine> liscin;
            liscin = mci.todosc();
            nomC.add("Escoja Una");
            for (int i = 0; i < liscin.size(); i++) {
                nomci = liscin.get(i);
                String nomb = nomci.getCin_nom();
                nomC.add(nomb);
            }
            return nomC;
        } catch (Exception e) {
            System.out.println("ERROR AL CREAR LA LISTA DE CINES: " + e);
            nomC.clear();
            return nomC;
        }
    }

    public List<String> todasc() {
        List<String> lisc = new ArrayList<>();
        lisc.clear();
        try {
            lisc.clear();
            List<ob_ciudad> lisci;
            lisci = ciu.todas();
            lisc.add("Escoja Una");
            for (int i = 0; i < lisci.size(); i++) {
                ciud = lisci.get(i);
                String nomc = ciud.getCiu_nom();
                lisc.add(nomc);
            }
            return lisc;
        } catch (Exception e) {
            System.out.println("ERROR AL CREAR LA LISTA DE Ciudades: " + e);
            lisc.clear();
            return lisc;
        }
    }

    public List<String> todsec() {
        List<String> lisc = new ArrayList<>();
        lisc.clear();
        try {

            lisc.clear();
            List<ob_sector> lisec;
            lisec = secto.todosS();
            lisc.add("Escoja Una");
            for (int i = 0; i < lisec.size(); i++) {
                sec = lisec.get(i);
                String nomc = sec.getSec_nom();
                lisc.add(nomc);
            }
            return lisc;
        } catch (Exception e) {
            System.out.println("ERROR AL CREAR LA LISTA DE Sectores: " + e);
            lisc.clear();
            return lisc;
        }
    }

    public void guardar() {
        obsuc.setSuc_id(0);
        obsuc.setSuc_nom(nnsuc);
        obsuc.setSuc_tel(nsuctel);
        ciud = ciu.ciuda(nsucciu.replace(" ", "%20"));
        obsuc.setCiu_id(ciud.getCiu_id());
        sec = secto.secto(nsucsec.replace(" ", "%20"));
        obsuc.setSec_id(sec.getSec_id());
        nomci = mci.cinebus(nsuci.replace(" ", "%20"));
        obsuc.setCin_id(nomci.getCin_id());
        obsuc.setSuc_ruc(nrucsuc);
        obsuc.setSuc_dir(nsucdir);
        obsuc.setSuc_esta("NUEVA");
        obsuc.setSuc_cor(ncorr);
        if(ms.guardar(obsuc)){
            try{
            conte = FacesContext.getCurrentInstance();
           conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "INFO", "Sucursal Registrada Correctamente"));
            }catch(Exception e){
                System.out.println("ERROR AL PONER EL MENSAJE: "+e);
            }
        }else{
            conte = FacesContext.getCurrentInstance();
           conte.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, "INFO", "Error al Registrar"));
        }
    }

}
