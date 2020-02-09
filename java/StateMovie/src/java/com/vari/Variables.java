/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vari;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author Panchito
 */
public class Variables {

    private String ip = "localhost";
    private String puertp = ":51289";

    public Variables() {
    }

    public String getIp() {
        return ip;
    }

    public String getPuertp() {
        return puertp;
    }

    public String converFech(Date fech) {
        String fechaid="";
        try{
        SimpleDateFormat da= new SimpleDateFormat("dd/MM/yyyy");
        fechaid=da.format(fech);
        return fechaid;
        }catch(Exception e){
            System.out.println("ERROR AL TRANSFORMAR LA FECHA: "+e);
            return fechaid;
        }
    }
}
