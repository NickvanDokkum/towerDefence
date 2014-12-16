using UnityEngine;
using System.Collections;


public class DayNightCycle : MonoBehaviour
{
	public float dayCycleLength;
	public float currentCycleTime;	
	public DayPhase currentPhase;
	public float hoursPerDay;
	public float dawnTimeOffset;
	public int worldTimeHour;
	public Color fullLight;
	public Color fullDark;	
	public Material dawnDuskSkybox;
	public Color dawnDuskFog;
	public Material daySkybox;
	public Color dayFog;
	public Material nightSkybox;
	public Color nightFog;
	private float dawnTime; 
	private float dayTime;
	private float duskTime;
	private float nightTime;
	private float quarterDay;
	private float lightIntensity;
	

	void Initialize()
	{
		currentCycleTime = 60;
		quarterDay = dayCycleLength * 0.25f;
		dawnTime = 0.0f;
		dayTime = dawnTime + quarterDay;
		duskTime = dayTime + quarterDay;
		nightTime = duskTime + quarterDay;
		if (light != null)
		{ lightIntensity = light.intensity; }
	}

	void Reset()
	{
		dayCycleLength = 120.0f;
		hoursPerDay = 24.0f;
		dawnTimeOffset = 3.0f;
		fullDark = new Color(32.0f / 255.0f, 28.0f / 255.0f, 46.0f / 255.0f);
		fullLight = new Color(253.0f / 255.0f, 248.0f / 255.0f, 223.0f / 255.0f);
		dawnDuskFog = new Color(133.0f / 255.0f, 124.0f / 255.0f, 102.0f / 255.0f);
		dayFog = new Color(180.0f / 255.0f, 208.0f / 255.0f, 209.0f / 255.0f);
		nightFog = new Color(12.0f / 255.0f, 15.0f / 255.0f, 91.0f / 255.0f);
		Skybox[] skyboxes = AssetBundle.FindObjectsOfTypeIncludingAssets(typeof(Skybox)) as Skybox[];
		foreach (Skybox box in skyboxes)
		{
			if (box.name == "DawnDusk Skybox")
			{ dawnDuskSkybox = box.material; }
			else if (box.name == "StarryNight Skybox")
			{ nightSkybox = box.material; }
			else if (box.name == "Sunny2 Skybox")
			{ daySkybox = box.material; }
		}
	}
	
	void Start()
	{
		Initialize();
	}
	
	void Update()
	{
		if (currentCycleTime > nightTime && currentPhase == DayPhase.Dusk)
		{
			SetNight();
		}
		else if (currentCycleTime > duskTime && currentPhase == DayPhase.Day)
		{
			SetDusk();
		}
		else if (currentCycleTime > dayTime && currentPhase == DayPhase.Dawn)
		{
			SetDay();
		}
		else if (currentCycleTime > dawnTime && currentCycleTime < dayTime && currentPhase == DayPhase.Night)
		{
			SetDawn();
		}
		
		UpdateWorldTime();
		UpdateDaylight();
		UpdateFog();
		currentCycleTime += Time.deltaTime;
		currentCycleTime = currentCycleTime % dayCycleLength;
	}

	public void SetDawn()
	{
		RenderSettings.skybox = dawnDuskSkybox; 
		if (light != null)
		{ light.enabled = true; }
		currentPhase = DayPhase.Dawn;
	}

	public void SetDay()
	{
		RenderSettings.skybox = daySkybox;
		RenderSettings.ambientLight = fullLight;
		if (light != null)
		{ light.intensity = lightIntensity; }
		currentPhase = DayPhase.Day;
	}
	

	public void SetDusk()
	{
		RenderSettings.skybox = dawnDuskSkybox;
		currentPhase = DayPhase.Dusk;
	}

	public void SetNight()
	{
		RenderSettings.skybox = nightSkybox;
		RenderSettings.ambientLight = fullDark;
		if (light != null)
		{ light.enabled = false; }
		currentPhase = DayPhase.Night;
	}
	

	private void UpdateDaylight()
	{
		if (currentPhase == DayPhase.Dawn)
		{
			float relativeTime = currentCycleTime - dawnTime;
			RenderSettings.ambientLight = Color.Lerp(fullDark, fullLight, relativeTime / quarterDay);
			if (light != null)
			{ light.intensity = lightIntensity * (relativeTime / quarterDay); }
		}
		else if (currentPhase == DayPhase.Dusk)
		{
			float relativeTime = currentCycleTime - duskTime;
			RenderSettings.ambientLight = Color.Lerp(fullLight, fullDark, relativeTime / quarterDay);
			if (light != null)
			{ light.intensity = lightIntensity * ((quarterDay - relativeTime) / quarterDay); }
		}
		
		transform.Rotate(Vector3.up * ((Time.deltaTime / dayCycleLength) * 360.0f), Space.Self);
	}
	

	private void UpdateFog()
	{
		if (currentPhase == DayPhase.Dawn)
		{
			float relativeTime = currentCycleTime - dawnTime;
			RenderSettings.fogColor = Color.Lerp(dawnDuskFog, dayFog, relativeTime / quarterDay);
		}
		else if (currentPhase == DayPhase.Day)
		{
			float relativeTime = currentCycleTime - dayTime;
			RenderSettings.fogColor = Color.Lerp(dayFog, dawnDuskFog, relativeTime / quarterDay);
		}
		else if (currentPhase == DayPhase.Dusk)
		{
			float relativeTime = currentCycleTime - duskTime;
			RenderSettings.fogColor = Color.Lerp(dawnDuskFog, nightFog, relativeTime / quarterDay);
		}
		else if (currentPhase == DayPhase.Night)
		{
			float relativeTime = currentCycleTime - nightTime;
			RenderSettings.fogColor = Color.Lerp(nightFog, dawnDuskFog, relativeTime / quarterDay);
		}
	}
	

	private void UpdateWorldTime()
	{
		worldTimeHour = (int)((Mathf.Ceil((currentCycleTime / dayCycleLength) * hoursPerDay) + dawnTimeOffset) % hoursPerDay) + 1;
	}
	
	public enum DayPhase
	{
		Night = 0,
		Dawn = 1,
		Day = 2,
		Dusk = 3
	}
}