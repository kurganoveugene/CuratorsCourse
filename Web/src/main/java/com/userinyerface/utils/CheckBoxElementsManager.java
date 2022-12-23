package com.userinyerface.utils;

import aquality.selenium.elements.interfaces.ICheckBox;
import java.util.List;

public class CheckBoxElementsManager {

    public static void selectElements(List<ICheckBox> list, int count){
        for(int i = 0; i < count; i ++){
           int index =  0 + (int) (Math.random() * list.size() - 1);
           if(list.get(index).isChecked()) {
               i--;
               continue;
           }
            list.get(index).click();
        }
    }
}
