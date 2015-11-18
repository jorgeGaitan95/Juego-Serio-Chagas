using UnityEngine;
using System.Collections;

public class Tienda : MonoBehaviour {

	public GUISkin skinTienda;
	public GUISkin skinBotonAtras;
	public GUISkin skinBoton;


	public Texture imgBoton;
	public Texture imgBtnAtras;


	public  bool mostrarTienda;
	public Texture imgAnimales;
	public Texture imgConstrucciones;
	public Texture imgArboles;

	public Texture establoNvl1;
	public Texture establoNvl2;
	public Texture imgChoza;
	public Texture imgChozaNvl1;
	public Texture imgCasa;
	public Texture madera;
	public Texture moneda;

	public Texture imgPalmaReal;
	public Texture imgPalmaPlatanera;


	private bool construcciones;
	private bool arboles;
	private bool animales;

	int contadorConstrucciones;
	BarrasJuego jugador;
	Misiones misiones;
	SeleccionarObjeto seleccionarObjetos;
	// Use this for initialization
	void Start () {
		jugador = GameObject.Find ("Main Camera").GetComponent<BarrasJuego>();
		misiones = GameObject.Find ("Misiones").GetComponent<Misiones> ();
		seleccionarObjetos = GameObject.Find ("Main Camera").GetComponent<SeleccionarObjeto> ();
		contadorConstrucciones = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		GUI.skin = skinBoton;
		if (GUI.Button (new Rect (30, Screen.height - 50, 50, 50), imgBoton)) {
			mostrarTienda=true;
		}
		if (mostrarTienda==true) {
			abrirTienda();
			GameObject.Find ("Notificaciones/MensajeNormal").GetComponent<MensajeOnGUI> ().mostarMensaje = false;
		}
	}

	void abrirTienda(){
		float tamañoX = Screen.width / 2;
		float tamañoY = Screen.height / 2;

		GUI.BeginGroup (new Rect (Screen.width/4, Screen.height/4,tamañoX ,tamañoY ));
			GUI.Box (new Rect(0, 0, tamañoX, tamañoY),"Tienda");
			float tamañoBoxX = (tamañoX - 20) / 4;
			GUI.BeginGroup (new Rect (10, 30, (tamañoX - 20) / 4, tamañoY - 30));
				
				GUI.Box (new Rect (0, 0,  tamañoBoxX, tamañoY - 40), "");
				
				float tamañoBotonY = (tamañoY - 80) / 3;
				if (GUI.Button (new Rect (10, 10, tamañoBoxX - 20, tamañoBotonY), imgAnimales)) {
					arboles=false;
					construcciones=false;
					animales=true;		
				}
				if (GUI.Button (new Rect (10, 20 + tamañoBotonY, tamañoBoxX - 20, tamañoBotonY), imgConstrucciones)) {
					arboles=false;
					animales=false;
					construcciones=true;
				}
				if (GUI.Button (new Rect (10, 30 + (tamañoBotonY * 2), tamañoBoxX - 20, tamañoBotonY), imgArboles)) {
					animales=false;
					construcciones=false;
					arboles=true;
				}
			GUI.EndGroup();
			
			float tamañoGrupo2X = ((tamañoX - 30) * 3) / 4;
			GUI.BeginGroup (new Rect (tamañoBoxX + 15, 30, tamañoGrupo2X, tamañoY - 30));
				GUI.Box (new Rect (0, 0, tamañoGrupo2X, tamañoY - 40), "");
				
				float tamañoGrupoImgX = (tamañoGrupo2X) / 3;
				float tamañoGrupoImgY = tamañoY - 40;
				GUI.skin = skinTienda;
				if (construcciones == true) {
					GUI.BeginGroup (new Rect (0, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "Choza Nvl 1");
					GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgChoza);
					GUI.Label (new Rect (tamañoGrupoImgX/2-20, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 12, 25, 30), madera);
					GUI.Label (new Rect (tamañoGrupoImgX/2+5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, 50, 20), "70");
					if(GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar")){
						if(jugador.recursos>=70)
						{
							instranciarObjeto("ChozaNvl1",60,0);
							jugador.recursos-=70;
							jugador.nivelRiesgo+=3;
							if(misiones.buscarMision("Mision1")==true)
								misiones.misionSeleccionada.GetComponent<Mision>().progreso+=1;
						}
					}
					GUI.EndGroup ();

					GUI.BeginGroup (new Rect (tamañoGrupoImgX, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "Choza Nvl 2");
					GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgChozaNvl1);
					GUI.Label (new Rect (tamañoGrupoImgX/2-20, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, 20, 20), moneda);
					GUI.Label (new Rect (tamañoGrupoImgX/2-5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, 50, 20), "400");
					if(GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar")){
						if(jugador.dinero>=400){
							instranciarObjeto("ChozaNvl2",120,0);
							jugador.dinero-=400;
							jugador.nivelRiesgo+=2;
						}
					}
					GUI.EndGroup ();

					GUI.BeginGroup (new Rect (2 * tamañoGrupoImgX, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "Casa");
					GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgCasa);
					GUI.Label (new Rect (tamañoGrupoImgX/2-20, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, 20, 20), moneda);
					GUI.Label (new Rect (tamañoGrupoImgX/2-5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, 50, 20), "700");
					if(GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar")){
						if(jugador.dinero>=700){
						instranciarObjeto("Casa",180,0);
						jugador.dinero-=700;
						}
					}
					GUI.EndGroup ();

				}


				if (arboles == true) {
					GUI.BeginGroup (new Rect (0, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "Jugo de caña");
					GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgPalmaReal);
					GUI.Label (new Rect (tamañoGrupoImgX/2-20, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, 20, 20), moneda);
					GUI.Label (new Rect (tamañoGrupoImgX/2-5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, 50, 20), "1000");
					if(GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar")){
					
					}
					GUI.EndGroup ();
					
		
				}


				if (animales == true) {
					
				GUI.BeginGroup (new Rect (0, 0, tamañoGrupoImgX, tamañoGrupoImgY));
				GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "EstabloNvl1");
				GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), establoNvl1);
				GUI.Label (new Rect (tamañoGrupoImgX/2-20, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 7, 20, 20), moneda);
				GUI.Label (new Rect (tamañoGrupoImgX/2-5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 7, 50, 20), "350");
				if(GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar")){

					if(jugador.dinero>=350)
					{
						instranciarObjeto("EstabloNvl1",90,1);
						jugador.dinero-=350;
						jugador.nivelRiesgo+=2;
						if(misiones.buscarMision("Mision3")==true)
							misiones.misionSeleccionada.GetComponent<Mision>().progreso+=1;
					}
				}
				GUI.EndGroup ();
				
				GUI.BeginGroup (new Rect (tamañoGrupoImgX, 0, tamañoGrupoImgX, tamañoGrupoImgY));
				GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "EstabloNvl2");
				GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), establoNvl2);
				GUI.Label (new Rect (tamañoGrupoImgX/2-20, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 7, 20, 20), moneda);
				GUI.Label (new Rect (tamañoGrupoImgX/2-5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 7, 50, 20), "500");
				if(GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar")){
				if(jugador.dinero>=500){
					instranciarObjeto("EstabloNvl2",150,1);
					jugador.dinero-=500;
					jugador.nivelRiesgo-=3;
					if(misiones.buscarMision("Mision3")==true)
						misiones.misionSeleccionada.GetComponent<Mision>().progreso+=1;
				}
			}
				GUI.EndGroup ();
			
				}
		
		GUI.EndGroup ();

		if (GUI.Button (new Rect (10, 5, 25, 15), imgBtnAtras)) {
			mostrarTienda=false;
		}
		   
		GUI.EndGroup ();

	}


	void instranciarObjeto(string nombre,int tiempo,int tipo){
		seleccionarObjetos.moverObjetos = true;
		Vector3 posicion=new Vector3(0,0,0);
		contadorConstrucciones++;
		GameObject construccion=GameObject.Find("ObjetosJuego/Construccion");
		posicion.x=500;
		posicion.y=construccion.transform.position.y;
		posicion.z = 300f;
		if (tipo == 1) 
			construccion.transform.localScale=new Vector3(1.7511f,1.7511f,1.7511f);
		else
			construccion.transform.localScale=new Vector3(2.785662f,2.785662f,2.785662f);
		construccion = Instantiate (construccion);
		construccion.name = "cosntruccion" + contadorConstrucciones;
		construccion.SetActive (true);
		GameObject padre = GameObject.Find ("ObjetosJuego");
		construccion.transform.position = posicion;
		construccion.transform.parent = padre.transform;
		construccion.GetComponent<construccion> ().buscarObjetoConstruccion (nombre, tiempo);
		mostrarTienda = false;

	}



	public void mejorarCosntruccion(string nombre,int tiempo,int tipo,Vector3 posicion){
	
		contadorConstrucciones++;
		GameObject construccion=GameObject.Find("ObjetosJuego/Construccion");
		if (tipo == 1) 
			construccion.transform.localScale=new Vector3(1.7511f,1.7511f,1.7511f);
		else
			construccion.transform.localScale=new Vector3(2.785662f,2.785662f,2.785662f);
		construccion = Instantiate (construccion);
		construccion.name = "cosntruccion" + contadorConstrucciones;
		construccion.SetActive (true);
		GameObject padre = GameObject.Find ("ObjetosJuego");
		construccion.transform.position = posicion;
		construccion.transform.parent = padre.transform;
		construccion.GetComponent<construccion> ().buscarObjetoConstruccion (nombre, tiempo);
	}
}
