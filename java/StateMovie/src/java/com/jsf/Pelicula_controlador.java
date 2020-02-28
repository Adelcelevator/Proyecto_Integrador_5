/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.modelo.mod_cine;
import com.modelo.mod_sucursal;
import com.objetos.ob_cine;
import com.objetos.ob_pelicula;
import com.objetos.ob_sucursal;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import javax.faces.event.AjaxBehaviorEvent;

/**
 *
 * @author Panchito
 */
@ManagedBean(name = "pel")
@SessionScoped
public class Pelicula_controlador implements Serializable {

    private FacesContext conte;
    private String termi, selecpel, cinesec="", sucsec="";
    private HashMap<String, Object> mapa = new HashMap<>();
    private mod_cine cines = new mod_cine();
    private List<ob_cine> todsc = new ArrayList<>();
    private List<ob_sucursal> sucrs = new ArrayList<>();
    private mod_sucursal sucs = new mod_sucursal();
    
    public String getSucsec() {
        return sucsec;
    }

    public void setSucsec(String sucsec) {
        this.sucsec = sucsec;
    }

    public String getCinesec() {
        return cinesec;
    }

    public void setCinesec(String cinesec) {
        this.cinesec = cinesec;
    }

    public String getTermi() {
        return termi;
    }

    public void setTermi(String termi) {
        this.termi = termi;
    }

    public String getSelecpel() {
        return selecpel;
    }

    public void setSelecpel(String selecpel) {
        this.selecpel = selecpel;
    }

    List<ob_pelicula> pelis = new ArrayList<>();

    public List<ob_pelicula> resulBus() {
        try {
            conte = FacesContext.getCurrentInstance();
            conte.getExternalContext().getSession(true);
            conte = FacesContext.getCurrentInstance();
            pelis = (List<ob_pelicula>) conte.getExternalContext().getSessionMap().get("lista_peli");
            return pelis;
        } catch (Exception e) {
            System.out.println("ERROR AL BUSCAR EN LA PAG 2: " + e);
        }
        pelis.clear();
        return pelis;
    }

    public String termi() {
        conte = FacesContext.getCurrentInstance();
        termi = (String) conte.getExternalContext().getSessionMap().get("termi");
        return termi;
    }

    public void selec(ob_pelicula obs) {
        conte = FacesContext.getCurrentInstance();
        conte.getExternalContext().getSession(true);
        selecpel = obs.getPel_nom();
        mapa.put("terminoh", selecpel);
        mapa.put("pel", obs);
    }

    public String valorH(AjaxBehaviorEvent evento) {
        String nom = (String) mapa.get("terminoh");
        return nom;
    }

    public List<String> cinest() {
        todsc.clear();
        List<String> nomci = new ArrayList<>();
        todsc = cines.todosc();
        nomci.add("Seleccione un Cine");
        for (ob_cine ci : todsc) {
            nomci.add(ci.getCin_nom());
        }
        return nomci;
    }

    public List<String> sucurs(AjaxBehaviorEvent env) {
        sucrs.clear();
        List<String> sucno = new ArrayList<>();
        sucno.clear();
        if ("Seleccione un Cine".equals(cinesec) || cinesec.equals("")) {
            return sucno;
        } else {
            ob_cine cin = cines.cinebus(cinesec);
            sucrs = sucs.sucsxci(cin.getCin_id());
            sucno.add("Seleccione una Sucursal");
            for (ob_sucursal su : sucrs) {
                sucno.add(su.getSuc_nom());
            }
            return sucno;
        }
    }

}
