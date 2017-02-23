using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsCounter: MonoBehaviour {

	/** Update time (in seconds) */
	public float Delay = 0.020f;
	/** Steps count */
	public int Steps = 0;
	
	void Start() {
		if (SystemInfo.supportsAccelerometer)
			InvokeRepeating("CountSteps", 0.0f, Delay);
	}

	private static int modulo(int x, int m) {
		int r = x % m;
		return r < 0 ? r + m : r;
	}
	public static IEnumerable<int> GetPreviousRange(int i, int range, int size) {
		int j = modulo(i-range, size);
		while (j != i) {
			j++;
			if (j == size) j = 0;
			yield return j;
		}
	}


	private double[] array_total = new double[100];
    private int i = 3;
	
	double accex;
	double accey;
	double accez;
	double accetotal;

	void CountSteps() {
		
		accex = Input.acceleration.x;
		accey = Input.acceleration.y;
        accez = Input.acceleration.z;		
		accetotal = System.Math.Sqrt(accex*accex+accey*accey+accez*accez);

		if (i==99) {
			array_total[i]=accetotal;
			i=0;
		}
		if (i==98) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==97) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==96) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==95) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==94) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==93) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==92) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==91) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==90) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==89) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==88) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==87) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==86) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==85) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==84) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==83) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==82) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==81) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==80) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==79) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==78) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==77) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==76) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==75) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==74) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==73) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==72) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==71) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==70) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==69) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==68) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==67) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==66) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==65) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==64) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==63) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==62) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==61) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==60) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==59) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==58) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==57) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==56) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==55) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==54) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==53) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==52) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==51) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==50) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==49) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==48) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==47) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==46) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==45) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==44) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==43) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==42) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==41) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==40) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==39) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==38) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==37) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==36) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==35) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==34) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==33) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==32) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==31) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==30) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==29) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==28) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==27) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==26) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==25) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==24) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==23) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==22) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==21) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==20) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==19) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==18) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==17) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==16) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==15) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==14) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==13) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==12) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==11) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==10) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==9) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==8) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==7) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==6) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==5) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==4) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==3) {
			array_total[i] = accetotal;
			int j = 99;
			while(j != i) {
				Debug.Log("i="+i+" j="+j);
				if (j==99) {
					j=0;
				}
			}
			i=i+1;
		}
		if (i==2) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==1) {
			array_total[i]=accetotal;
			i=i+1;
		}
		if (i==0) {
			array_total[i]=accetotal;
			i=i+1;
		}
	}

}
