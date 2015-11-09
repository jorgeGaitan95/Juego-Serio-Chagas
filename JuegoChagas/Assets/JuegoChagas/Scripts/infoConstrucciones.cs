using UnityEngine;
using System.Collections;

public class infoConstrucciones : MonoBehaviour {

	public string nombreConstruccion;
	public Texture imagenConstruccion;
	public int costoMejora;
	public string mejora;
	public string beneficios;
	public int reduccionNivelRiesgo;
	public GameObject[] construcciones;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool buscarInformacion(string nombre){
		for (int i=0; i<construcciones.Length; i++) {
			if(construcciones[i].name==nombre)
			{
				GameObject mejoraCosntruccion=construcciones[i+1];
				DatosConstruccion datos=mejoraCosntruccion.GetComponent<DatosConstruccion>();
				nombreConstruccion=datos.nombre;
				imagenConstruccion=datos.imagenConstruccion;
				costoMejora=datos.costoMejora;
				mejora=datos.mejoras[0];
				for(int j=1;j<datos.mejoras.Length;j++){
					mejora+="\n"+datos.mejoras[j];
				}
				beneficios=datos.beneficios;
				reduccionNivelRiesgo=datos.reduccionNivelRiesgo;
				return true;
			}
		}
		return false;
	}
}
