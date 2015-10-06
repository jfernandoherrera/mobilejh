package com.example.mobilejh;

import android.app.Activity;
import android.content.Intent;
import android.content.IntentSender;

import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.util.Log;
import android.view.View;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.plus.Plus;


import static com.example.mobilejh.R.*;

public class LoginActivity extends Activity implements ActivityCompat.OnRequestPermissionsResultCallback,GoogleApiClient.ConnectionCallbacks,
        GoogleApiClient.OnConnectionFailedListener,View.OnClickListener{
    /* Is there a ConnectionResult resolution in progress? */
    private boolean mIsResolving = false;

    /* Should we automatically resolve ConnectionResults when possible? */
    private boolean mShouldResolve = false;
    /* Request code used to invoke sign in user interactions. */
    private static final int RC_SIGN_IN = 0;

    /* Client used to interact with Google APIs. */
    private GoogleApiClient mGoogleApiClient;
    private boolean mIntentInProgress;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(layout.activity_login);

        findViewById(id.sign_in_button).setOnClickListener(this);
        mGoogleApiClient = new GoogleApiClient.Builder(this)
                .addConnectionCallbacks(this)
                .addOnConnectionFailedListener(this)
                .addApi(Plus.API, Plus.PlusOptions.builder().build())
                .addScope(Plus.SCOPE_PLUS_LOGIN)
                .addScope(Plus.SCOPE_PLUS_PROFILE)
                .build();
    }

    private void onSignInClicked() {
        // User clicked the sign-in button, so begin the sign-in process and automatically
        // attempt to resolve any errors that occur.
        mShouldResolve = true;
        mGoogleApiClient.connect();

        // Show a message to the user that we are signing in.
       // mStatus.setText(R.string.signing_in);
    }
    @Override
    public void onClick(View v) {
        if (!mGoogleApiClient.isConnecting()) {
            if (v.getId() == R.id.sign_in_button) {
                onSignInClicked();
            }
        }
        Log.d("Activity Result:", "oncLICK" );

    }
    @Override
    public void onConnectionFailed(ConnectionResult connectionResult) {
        // Could not connect to Google Play Services.  The user needs to select an account,
        // grant permissions or resolve an error in order to sign in. Refer to the javadoc for
        // ConnectionResult to see possible error codes.
        Log.d("Connection failed", "onConnectionFailed:" + connectionResult);

        if (!mIsResolving && mShouldResolve) {
            if (connectionResult.hasResolution()) {
                try {
                    connectionResult.startResolutionForResult(this, RC_SIGN_IN);
                    mIsResolving = true;
                } catch (IntentSender.SendIntentException e) {
                    Log.e("Connection failed", "Could not resolve ConnectionResult.", e);
                    mIsResolving = false;
                    mGoogleApiClient.connect();
                }
            } else {
                // Could not resolve the connection result, show the user an
                // error dialog.
              //  showErrorDialog(connectionResult);
            }
        } else {
            // Show the signed-out UI
           // showSignedOutUI();
        }
    }

    @Override
    public void onConnected(Bundle bundle) {
        mShouldResolve = false;




            Log.d("Activity Result:", "onconnected" );
        Intent intent = new Intent(LoginActivity.this, ToDoActivity.class);
        Bundle b = new Bundle();

          ActivityCompat.requestPermissions(LoginActivity.this, new String[]{"android.permission.GET_ACCOUNTS"}, 0);

        b.putString("email", Plus.AccountApi.getAccountName(mGoogleApiClient)); //Your id
        intent.putExtras(b); //Put your id to your next Intent
        startActivity(intent);
        finish();


    }

    @Override
    public void onConnectionSuspended(int i) {
        mGoogleApiClient.connect();
    }
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Log.d("Activity Result:", "onActivityResult:" + requestCode + ":" + resultCode + ":" + data);

        if (requestCode == RC_SIGN_IN) {
            mIntentInProgress = false;

              //  mGoogleApiClient.connect();

            // If the error resolution was not successful we should not resolve further.
            if (resultCode != RESULT_OK) {
                mShouldResolve = false;
            }

            mIsResolving = false;

        }
    }
    @Override
    protected void onStart() {
        super.onStart();
        mGoogleApiClient.connect();
    }

    @Override
    protected void onStop() {
        super.onStop();
        mGoogleApiClient.disconnect();
    }



}
