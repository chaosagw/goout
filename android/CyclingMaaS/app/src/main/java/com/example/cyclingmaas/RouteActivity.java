package com.example.cyclingmaas;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

public class RouteActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_route);
        setTitle("Route page");
        Button btn1 = findViewById(R.id.button1);
        Button btn2 = findViewById(R.id.button2);
        Button btn3 = findViewById(R.id.button3);


        btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ImageView iv = findViewById(R.id.imageView);
                iv.setImageResource(R.drawable.route2);
            }
        });

        btn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ImageView iv = findViewById(R.id.imageView);
                iv.setImageResource(R.drawable.route);
            }
        });

        btn3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ImageView iv = findViewById(R.id.imageView);
                iv.setImageResource(R.drawable.maas);
            }
        });
    }
    @Override
    public void finish(){
        super.finish();
        overridePendingTransition(R.animator.activity_close_enter, R.animator.activity_close_exit);
    }
}
