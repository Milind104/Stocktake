package crc64d65d44dbca70553a;


public class WebCallbackActivity
	extends crc6468b6408a11370c2f.WebAuthenticatorCallbackActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MauiStockTake.UI.Platforms.Android.WebCallbackActivity, MauiStockTake.UI", WebCallbackActivity.class, __md_methods);
	}


	public WebCallbackActivity ()
	{
		super ();
		if (getClass () == WebCallbackActivity.class) {
			mono.android.TypeManager.Activate ("MauiStockTake.UI.Platforms.Android.WebCallbackActivity, MauiStockTake.UI", "", this, new java.lang.Object[] {  });
		}
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
