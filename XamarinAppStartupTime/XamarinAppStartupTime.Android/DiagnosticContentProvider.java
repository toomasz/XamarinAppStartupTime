package com.my.contentproviders;

import android.util.Log;
import android.widget.Toast;  
import java.util.TimeZone;
import java.util.Date;

public class DiagnosticContentProvider
	extends android.content.ContentProvider
{
	static Date _startupTime;

	public DiagnosticContentProvider ()
	{
		_startupTime = new Date();
	    Log.i("DIAGNOSTICS","App started");
	}

	public static Date GetStartupTime()
	{
		return _startupTime;
	}

	@Override
	public boolean onCreate ()
	{
		return true;
	}

	@Override
	public void attachInfo (android.content.Context context, android.content.pm.ProviderInfo info)
	{	

		super.attachInfo (context, info);
	}

	@Override
	public android.database.Cursor query (android.net.Uri uri, String[] projection, String selection, String[] selectionArgs, String sortOrder)
	{
		throw new RuntimeException ("This operation is not supported.");
	}

	@Override
	public String getType (android.net.Uri uri)
	{
		throw new RuntimeException ("This operation is not supported.");
	}

	@Override
	public android.net.Uri insert (android.net.Uri uri, android.content.ContentValues initialValues)
	{
		throw new RuntimeException ("This operation is not supported.");
	}

	@Override
	public int delete (android.net.Uri uri, String where, String[] whereArgs)
	{
		throw new RuntimeException ("This operation is not supported.");
	}

	@Override
	public int update (android.net.Uri uri, android.content.ContentValues values, String where, String[] whereArgs)
	{
		throw new RuntimeException ("This operation is not supported.");
	}
}