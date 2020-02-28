/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.objetos;

import java.io.Serializable;

/**
 *
 * @author Panchito
 */
public class ob_pelicula implements Serializable{

    private int pel_id;
    private String pel_nom, pel_pro, pel_dire, pel_cla, pel_est, pel_linkv, pel_linkba;

    public ob_pelicula() {
    }

    public int getPel_id() {
        return pel_id;
    }

    public void setPel_id(int pel_id) {
        this.pel_id = pel_id;
    }

    public String getPel_nom() {
        return pel_nom;
    }

    public void setPel_nom(String pel_nom) {
        this.pel_nom = pel_nom;
    }

    public String getPel_pro() {
        return pel_pro;
    }

    public void setPel_pro(String pel_pro) {
        this.pel_pro = pel_pro;
    }

    public String getPel_dire() {
        return pel_dire;
    }

    public void setPel_dire(String pel_dire) {
        this.pel_dire = pel_dire;
    }

    public String getPel_cla() {
        return pel_cla;
    }

    public void setPel_cla(String pel_cla) {
        this.pel_cla = pel_cla;
    }

    public String getPel_est() {
        return pel_est;
    }

    public void setPel_est(String pel_est) {
        this.pel_est = pel_est;
    }

    public String getPel_linkv() {
        return pel_linkv;
    }

    public void setPel_linkv(String pel_linkv) {
        this.pel_linkv = pel_linkv;
    }

    public String getPel_linkba() {
        return pel_linkba;
    }

    public void setPel_linkba(String pel_linkba) {
        this.pel_linkba = pel_linkba;
    }

}
