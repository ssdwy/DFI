   M S B A M L   `   `   `  ����K  GDFI_UE4_Gruppe11, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DFI_UE4_Gruppe11DFI_UE4_Gruppe11  5   	   %    DFI_UE4_Gruppe11.Materialbedarf   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.16.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DFI_UE4_Gruppe11     5   	     � Title$  Materialbedarf��5   	   $	��263��6    $	��330��6-   .��5	      � $��0,0,-6.8,-0.4q�6    � ColumnDefinitions 5
   
   �� 5      $
��314* �6   �� 5      $��9* �6   .+�5   
   �� $��Bezeichnung:��6   $��10,10,0.2,-0.4q�5      $��2��6(   �� 5   
   -   5         ��Name$ Gew_BezeichnungTextbox��5      $
��Left=�5      $	��Top=�5      $��23��5      $	��178��5      $��
125,10,0,0q�5      �� 5   
   $��Adresse:��6   $��10,38,0.2,-0.4q�5      $��2��6(   �� 5   
   -   5        $ Gew_AdresseTextbox��5      $
��Left=�5      $	��Top=�5      $��23��5      $	��178��5      $��
125,38,0,0q�5      �� 5   
   $��Anzahl Pflanze:��6   $��10,66,0.2,-0.4q�5      $��2��6(   �� 5    
   -   5        $ Anzahl_PflanzeTextbox��5       $
��Left=�5!      $	��Top=�5"      $��23��5#      $	��178��5$      $��
125,66,0,0q�5%      �� 5&   
   $��Zeitraum Von:��6   $��10,105,0.2,-0.4q�5'      $��2��6)   (  "System.Windows.Controls.DatePicker  5(   
   -   5          Name$ DatumZeit_Von��5.      $��23��5(      $	��178��5)      $
��Left=�5+      $	��Top=�5,      $��125,105,0,0q�5-      5.      �� 5/   
   $��Zeitraum Bis:��6   $��10,133,0.2,-0.4q�50      $��2��6)     51   
   -   5        $ DatumZeit_bis��57      $��23��51      $	��178��52      $
��Left=�54      $	��Top=�55      $��125,133,0,0q�56      57      �� 58   
   $��Wasserverbrauch:��6   $��10,161,0.2,-0.4q�59      $��2��6)   �� 5:   
   -   5        $ WasserverbrauchTextBox��5:      $��125,161,0,0q�5;      $
��Left=�5<      $	��Top=�5=      $��23��5>      $	��178��5?      �� 5@   
   $��Düngerverbrauch:��6   $��10,189,0.2,-0.4q�5A      $��2��6)   �� 5B   
   -   5        $ DuengerverbrauchTextbox��5B      $��125,189,0,0q�5C      $
��Left=�5D      $	��Top=�5E      $	��178��5F      $��23��5G      �� 5H   
   $��l��6   $
��Left=�6   $��304,161,0,0q�67   $	��Top=�6L   $��15��6d   �� 5I   
   $��g��6   $
��Left=�6   $��303,188,0,0q�67   $	��Top=�6L   $��18��6d   $��2��6o   5N      5O      