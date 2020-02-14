/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.jsf;

import com.modelo.mod_cine;
import com.modelo.mod_sucursal;
import com.objetos.ob_cine;
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
    private String nsuci,nnsuc,nrucsuc,ntelsuc,ncorr,nsucdir,nsuctel;
    List<ob_sucursal> lis = new ArrayList<ob_sucursal>();
    mod_sucursal ms = new mod_sucursal();

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

    public List<String> todos() {
        List<String> nomC = new ArrayList<String>();
        try {
            nomC.clear();
            mod_cine mci = new mod_cine();
            List<ob_cine> lis;
            lis = mci.todosc();
            nomC.add("Escoja Una");
            for(int i=0;i<lis.size();i++){
                ob_cine nom= new ob_cine();
                nom = lis.get(i);
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
    public void guardar(){
        System.out.println("SALIDA DE TODO: "+nsuci);
    }
}
