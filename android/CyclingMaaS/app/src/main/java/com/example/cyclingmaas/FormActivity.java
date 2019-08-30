package com.example.cyclingmaas;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class FormActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_form);
    }
    @Override
    public void finish(){
        super.finish();
        overridePendingTransition(R.animator.activity_close_enter, R.animator.activity_close_exit);
    }
}
