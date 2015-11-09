using UnityEngine;
using System.Collections;

public class LimpiarConstruccion : MonoBehaviour {



	public int tiempoEspera;
	public int dineroRecompensa;
	public bool construccionlimpia;
	bool mostrarAlerta;
	public bool mostrarMenu;
	bool mostarMejora;
	bool mejorarConstruccion;
	float tiempoActual=0;
	float tiempoMaximo=1;
	public int progreso;
	public GUISkin skin;
	public GUISkin skinMejoras;
	public Texture cerrarVentana;
	public Texture alerta;
	infoConstrucciones scriptInformacion;
	Misiones misiones;
	BarrasJuego player;
	Tienda tienda;

	// Use this for initialization
	void Start () {
		misiones = GameObject.Find ("Misiones").GetComponent<Misiones> ();
		player = GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
		tienda = GameObject.Find ("Main Camera").GetComponent<Tienda> ();
		mejorarConstruccion = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(progreso<=tiempoEspera&&construccionlimpia==true){
			tiempoActual+=Time.deltaTime;
			
			if(tiempoActual>=tiempoMaximo){
				tiempoActual=0;
				progreso++;
			}
			
			if (progreso == tiempoEspera){
				mostrarAlerta=true;
				player.nivelRiesgo+=1;
				construccionlimpia=false;
				progreso=0;
			}
		}
	}


	void OnGUI(){
		if (mostrarAlerta == true) {
			GUI.skin=skin;
			Vector3 posicion=Camera.main.WorldToScreenPoint(this.transform.position);
			posicion.y=Screen.height-posicion.y;

			GUI.Box(new Rect(posicion.x-15,posicion.y-40,30,30),alerta);
		}

		if (mostrarMenu == true) {
			GUI.skin = null;
			Vector3 posicion = Camera.main.WorldToScreenPoint (this.transform.position);
			posicion.y = Screen.height - posicion.y;
			if (construccionlimpia == false) {
				if (GUI.Button (new Rect (posicion.x, posicion.y, 65, 20), "Asear")) {
					limpiarCasa ();
					mostrarMenu = false;
					
				}
			}
			if (this.name != "casa" || this.name != "establoNvl2") {
				if (GUI.Button (new Rect (posicion.x, posicion.y + 23, 65, 20), "Mejorar")) {
					mostrarMenu = false;
					mejorar ();
				}

				if (GUI.Button (new Rect (posicion.x, posicion.y + 46, 65, 20), "Cancelar"))
					mostrarMenu = false;
			}else{
				if (GUI.Button (new Rect (posicion.x, posicion.y + 23, 65, 20), "Cancelar"))
					mostrarMenu = false;
			}
		}

		if (mostarMejora == true) {
			float tamañoX = Screen.width / 2;
			float tamañoY = Screen.height / 2;
			GUI.skin=skinMejoras;
			GUI.BeginGroup (new Rect (Screen.width/4, Screen.height/4,tamañoX ,tamañoY ));
			GUI.Box (new Rect(0, 0, tamañoX, tamañoY),"Mejorar Construccion");
			float tamañoBoxX = (tamañoX - 20) / 4;

			if(GUI.Button(new Rect(tamañoX-40,10,60,60),cerrarVentana))
				mostarMejora=false;

			GUI.BeginGroup (new Rect (10, 10, (tamañoX - 20) / 4, tamañoY));
			GUI.Label(new Rect((tamañoBoxX/2)-40, 20, 80, 30),scriptInformacion.nombreConstruccion);
			GUI.Label(new Rect(0,tamañoY/2-(tamañoBoxX/2),tamañoBoxX,tamañoBoxX),scriptInformacion.imagenConstruccion);
			GUI.Label(new Rect((tamañoBoxX/2),tamañoY-60,60,30),"$ "+scriptInformacion.costoMejora);
			if(GUI.Button(new Rect((tamañoBoxX/2)-40,tamañoY-45,80,30),"Mejorar"))
			{
				if(player.dinero>=scriptInformacion.costoMejora)
				{
					mostarMejora=false;
					player.dinero-=scriptInformacion.costoMejora;
					player.nivelRiesgo-=scriptInformacion.reduccionNivelRiesgo;
					int tipo=0;
					if(scriptInformacion.nombreConstruccion=="Establo Nvl2")
						tipo=1;
					if(misiones.buscarMision("Mision4")==true)
						misiones.misionSeleccionada.GetComponent<Mision>().progreso+=1;
					tienda.mejorarCosntruccion(scriptInformacion.nombreConstruccion,scriptInformacion.tiempoConstruccion,tipo,this.transform.position);
					Destroy(gameObject);
				}
			}
			GUI.EndGroup();

			float tamañoGrupo2=3*((tamañoX - 20) / 4);
			GUI.BeginGroup(new Rect(tamañoBoxX+10,10,tamañoGrupo2-5,tamañoY));

			GUI.Label(new Rect(10,20,80,20),"MEJORAS");
			GUI.Label(new Rect(20,40,tamañoGrupo2-10,tamañoY/2),scriptInformacion.mejora);


			GUI.Label(new Rect(10,(tamañoY/2)+10,80,20),"BENEFICIOS");
			GUI.Label(new Rect(20,(tamañoY/2)+30,tamañoGrupo2-20,(tamañoY/2)-50),scriptInformacion.beneficios);

			GUI.EndGroup();

			GUI.EndGroup();
		}
	}
	
	void limpiarCasa()
	{
		if(misiones.buscarMision("Mision2")==true)
			misiones.misionSeleccionada.GetComponent<Mision>().progreso+=1;
		player.dinero += dineroRecompensa;
		player.nivelRiesgo -= 1;
		player.experiencia += 3;
		construccionlimpia = true;
		mostrarAlerta = false;
	}

	void mejorar(){
		GameObject informacionConstrucciones = GameObject.Find ("ObjetosJuego/infoConstrucciones");
		scriptInformacion = informacionConstrucciones.GetComponent<infoConstrucciones>();
		if (scriptInformacion!=null) {
			bool existeMejora=scriptInformacion.buscarInformacion(this.name);
				if(existeMejora== true)
				{
					mostarMejora=true;
				}
		}

	}
}



