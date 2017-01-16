
import java.util.*;
public class Natural_Lang {
	public static void main(String arg[]){
	String natu_lang = "A is placed on B ";
	System.out.println(Natural(natu_lang));
	}
	public static String Natural(String natu_lang){
		String str;
		String words[] = natu_lang.split("\\s");
		String clearkey[] = {"not","nothing","clear"};
		String holdingkey[] = {"have","hold","holding"};
		for(int i = 0; i < words.length; i++){
			if(words[i].equals("A") || words[i].equals("B") || words[i].equals("C")){
				for(int j = i; j < words.length; j++){
					if(words[j].equals("on")){
						for(int k = j + 1; k < words.length; k++){
							if(words[k].equals("A") || words[k].equals("B") || words[k].equals("C")){
								return(words[i]+" on "+words[k]);
							}
						}return("ontable "+words[i]);
					}
				}if(Arrays.asList(words).contains(clearkey)){
					return("clear "+words[i]);
				}else if(Arrays.asList(words).contains(holdingkey)){
					return("holding "+words[i]);
				}
			}
		}
		return("err");
	}
}