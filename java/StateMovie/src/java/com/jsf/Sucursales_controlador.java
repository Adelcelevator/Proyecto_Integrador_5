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
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

/**
 *
 * @author Panchito
 */
@ManagedBean(name = "sucursal")
@SessionScoped
public class Sucursales_controlador implements Serializable {

    private String nsuci, nnsuc, nrucsuc, ntelsuc, ncorr, nsucdir, nsuctel, nsucci,nsucsec;
    private List<ob_sucursal> lis = new ArrayList<>();
    private mod_sucursal ms = new mod_sucursal();

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

    public String getNsucci() {
        return nsucci;
    }

    public void setNsucci(String nsucci) {
        this.nsucci = nsucci;
    }

    public Sucursales_controlador() {
    }

    public List<ob_sucursal> todo() {
        try {
            lis.clear();
            lis = ms.tods();
            return lis;
        } catch (Exception e) {
            System.out.println("ERROR: " + e);
            lis.clear();
            return lis;
        }
    }

    public List<String> todos() {
        List<String> nomC = new ArrayList<>();
        try {
            nomC.clear();
            mod_cine mci = new mod_cine();
            List<ob_cine> liscin;
            liscin = mci.todosc();
            nomC.add("Escoja Una");
            for (int i = 0; i < liscin.size(); i++) {
                ob_cine nom;
                nom = liscin.get(i);
                String nomb = nom.getCin_nom();
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
            mod_ciudad ciu = new mod_ciudad();
            List<ob_ciudad> lisci;
            lisci = ciu.todas();
            lisc.add("Escoja Una");
            ob_ciudad ciud;

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
            mod_sector secto = new mod_sector();
            List<ob_sector> lisec;
            lisec = secto.todosS();
            lisc.add("Escoja Una");
            ob_sector sec;

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
        System.out.println("SALIDA DE TODO: " + nsuci);
    }

}
