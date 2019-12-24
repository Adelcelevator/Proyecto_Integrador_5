package com.state.movie.statemovie;

import android.os.AsyncTask;
import android.util.Log;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class CL_Conexiones extends AsyncTask<Void, Void, String> {


    @Override
    protected String doInBackground(Void... voids) {
        String json = "";
        try {
            final String url = "http://192.168.43.213:51289/api/Usuario";
            URL wurl = new URL(url);
            HttpURLConnection con = (HttpURLConnection) wurl.openConnection();
            con.setRequestMethod("GET");
            con.setConnectTimeout(5000);
            con.setRequestProperty("ACCEPT", "application/json");
            BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream()));
            json=br.readLine();
            Log.i("INFO","========================================================");
            Log.i("INFO","valor del JSON: "+json);
            return json;
        } catch (Exception e) {
            Log.e("ERROR","========================================================");
            Log.e("ERROR","AQUI EN LA CONECION: "+e);
        }
        return json;
    }
}
