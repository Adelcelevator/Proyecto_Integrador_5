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
public class ob_cine implements Serializable{
    private int cin_id;
    private String cin_nom,cin_est;

    public ob_cine() {
    }

    public int getCin_id(){
        return cin_id;
    }

    public void setCin_id(int cin_id) {
        this.cin_id = cin_id;
    }

    public String getCin_nom() {
        return cin_nom;
    }

    public void setCin_nom(String cin_nom) {
        this.cin_nom = cin_nom;
    }

    public String getCin_est() {
        return cin_est;
    }

    public void setCin_est(String cin_est) {
        this.cin_est = cin_est;
    }
    
}
