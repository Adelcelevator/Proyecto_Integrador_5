package com.state.movie.statemovie;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;


public class MainActivity extends AppCompatActivity {
    public Button btn;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btn = findViewById(R.id.btn_prueba);
        try {
            getSupportActionBar().hide();
        } catch (Exception e) {
            Log.e("ERORR", "ERROR AL ESCONCER ESA COSA: " + e);
        }
        String ip="192.168.1.3";
        String puerto="51289";
        final String url="http://"+ip+":"+puerto+"/api/Usuario";
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Context contexto = getBaseContext();
                RequestQueue res = Volley.newRequestQueue(contexto);
                StringRequest resq = new StringRequest(Request.Method.GET, url,
                        new Response.Listener<String>() {
                            @Override
                            public void onResponse(String response) {
                                // Display the first 500 characters of the response string.
                                Log.i("INFO","RESPUESTA: "+response);
                            }
                        }, new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        Log.e("Eroror","VALIO GATO POR ESTO: "+error);
                    }
                });
                res.add(resq);

            }
        });
    }
}
