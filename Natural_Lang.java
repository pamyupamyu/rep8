
import java.util.Arrays;
public class Natural_Lang {
	public static void main(String arg[]){
	String natural_state = "B ontable";
	String natural_order = "remove A from B";
	System.out.println(Natural_State(natural_state));
	System.out.println(Natural_Order(natural_order));
	}
	public static String Natural_State(String natu_lang){
		String str;
		String words[] = natu_lang.split("\\s");
		String clearkey[] = {"not","nothing","clear"};
		String holdingkey[] = {"have","hold","holding"};
		String blockkey[] = {"A","B","C"};
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
				}if(Contains_List(words,clearkey)){
					return("clear "+words[i]);
				}else if(Contains_List(words,holdingkey)){
					return("holding "+words[i]);
				}
			}if(!Contains_List(words,blockkey))return("handEmpty");
		}
		return("err");
	}

	public static String Natural_Order(String natu_lang){
		String str;
		String words[] = natu_lang.split("\\s");
		String placekey[] = {"put","place"};
		String removekey[] = {"remove","pick","from"};
		String pickkey[] = {"remove","pick","from"};
		String putkey[] = {"put","place"};
		if(Contains_List(words,placekey) || Contains_List(words,putkey)){
			for(int i = 0; i < words.length; i++){
				if(words[i].equals("A") || words[i].equals("B") || words[i].equals("C")){
					for(int j = i; j < words.length; j++){
						if(words[j].equals("on")){
							for(int k = j + 1; k < words.length; k++){
								if(words[k].equals("A") || words[k].equals("B") || words[k].equals("C")){
									if(Contains_List(words,placekey))return("Place "+words[i]+" on "+words[k]);
								}
							}if(Contains_List(words,putkey))return("put "+words[i]+" down on the table");
						}
					}
				}
			}
		}
		else if(Contains_List(words,removekey) || Contains_List(words,pickkey)){
			for(int i = 0; i < words.length; i++){
				if(words[i].equals("A") || words[i].equals("B") || words[i].equals("C")){
					for(int j = i; j < words.length; j++){
						if(words[j].equals("on") || words[j].equals("from")){
							for(int k = j + 1; k < words.length; k++){
								if(words[k].equals("A") || words[k].equals("B") || words[k].equals("C")){
									if(Contains_List(words,removekey))return("remove "+words[i]+" from top on "+words[k]);
								}
							}if(Contains_List(words,pickkey))return("pick up "+words[i]+" from the table");
						}
					}
				}
			}
		}
		return("err");
	}

	public static boolean Contains_List(String[] words, String[] key){
		for(int i = 0; i < key.length; i++){
			if(Arrays.asList(words).contains(key[i]))return true;
		}
		return false;
	}

}