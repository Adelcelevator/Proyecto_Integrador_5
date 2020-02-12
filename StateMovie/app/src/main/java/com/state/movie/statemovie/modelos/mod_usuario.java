package com.state.movie.statemovie.modelos;

import android.content.Context;
import android.util.Log;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.state.movie.statemovie.objetos.Variables;
import com.state.movie.statemovie.objetos.usuario;

import org.json.JSONObject;

public class mod_usuario {
    usuario usu = new usuario();
    public usuario consulta(Context contexto,String valora){

        Variables vars = new Variables();
        final String url = "http://" + vars.getIp() + ":" + vars.getPuerto() + "/api/Usuario?usu_id=" +valora;
        RequestQueue res = Volley.newRequestQueue(contexto);
        StringRequest resq = new StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject json = new JSONObject((response.replace("]", "")).replace("[", ""));
                            if (json.getInt("usu_id") != 0) {
                                usu.setUsu_id(json.getInt("usu_id"));
                                usu.setCli_id(json.getInt("cli_id"));
                                usu.setTus_id(json.getInt("tus_id"));
                                usu.setUsu_usu(json.getString("usu_usu"));
                                usu.setUsu_pass(json.getString("usu_pass"));
                            } else {
                                Log.i("INFO", "No Existe el Usuario");
                            }
                        } catch (Exception e) {
                            Log.e("error", "Error: " + e);
                        }
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Eroror", "VALIO GATO POR ESTO: " + error);
            }
        });
        res.add(resq);
        return usu;
    }
}
