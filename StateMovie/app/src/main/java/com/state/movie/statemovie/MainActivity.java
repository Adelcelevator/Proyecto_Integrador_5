package com.state.movie.statemovie;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;


public class MainActivity extends AppCompatActivity {
    public Button btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btn = findViewById(R.id.btn_prueba);
        getSupportActionBar().hide();
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    CL_Conexiones con = new CL_Conexiones();
                    con.execute();
                    Log.i("INFO", "===================================================");
                    //Log.i("INFO", "VALOR DEL JSON EN EL OTRO LADO: " + json);
                } catch (Exception e) {
                    Log.e("ERROR","======================================================");
                    Log.e("ERROR","VALIO GATO POR ESTO: "+e);
                }
            }
        });
    }
}
