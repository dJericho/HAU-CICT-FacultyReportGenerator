   M S B A M L   `   `   `  ����J  FReportGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ReportGeneratorReportGenerator  5          ReportGenerator.Profile   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ReportGenerator     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��auto��5      $
��auto��6-   $��Stretch=�5	      $��Stretch=�6,     � DataContext  5
        ReportGenerator.LoadsVM  5   
   .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��5,5,5,5q�6   $	��350��6/   $
��Left=�6<   $	��350��6W   $	��Top=�6c   .��5      � .+�5      �� $
��Name��6   $
��Left=�6'   $	��Top=�6B   $��	53,32,0,0q�6Z   $
��Bold"�6m   $��14(�6   �� 5      $
��Role��6   $
��Left=�6'   $	��Top=�6B   $��	63,66,0,0q�6Z   $
��Bold"�6m   $��14(�6   �� 5      $��ID��6   $
��Left=�6%   $	��Top=�6@   $��
77,100,0,0q�6X   $
��Bold"�6l   $��14(�6~   �� 5      $��	Undergrad��6   $
��Left=�6,   $	��Top=�6G   $��
22,134,0,0q�6_   $
��Bold"�6s   $��14(�6�   �� 5      $��Postgrad��6   $
��Left=�6+   $	��Top=�6F   $��
34,201,0,0q�6^   $
��Bold"�6r   $��14(�6�   �� 5      -   5         ��Name$
 name��5      $
��Left=�6(   $��29��6C    �� TextWrapping$
 Wrap=�6O   $	��Top=�6c   $	��215��6{   $��108,32,-15,0q�6�   $��14(�6�   �� 5      -   5        $
 role��5      {�.  $
��Left=�6:   $��29��6U   $
 Wrap=�6a   $	��Top=�6u   $	��215��6�   $��108,66,-15,0q�6�   $��14(�6�   �� 5      -   5        $ id��5      {�.  $
��Left=�68   $��29��6S   $
 Wrap=�6_   $	��Top=�6s   $	��215��6�   $��108,100,-15,0q�6�   $��14(�6�   �� 5      -   5        $ 	undergrad��5      $
��Left=�6-   $��29��6H   $
 Wrap=�6T   $	��Top=�6h   $	��215��6�   $��108,134,-15,0q�6�   $��14(�6�   �� 5      -   5        $ postgrad��5      $
��Left=�6,   $��29��6G   $
 Wrap=�6S   $	��Top=�6g   $	��215��6   $��108,202,-15,0q�6�   $��14(�6�   �� 5      -   5         ��Name$ btnSave��5      $
��Save��6@    #  MaterialDesignRaisedLightButton#���   6O   $
��Left=�6�   $	��Top=�6�   $��75��6�   $��
28,293,0,0q�6�   �� 5      $
��Year��6   $
��Left=�6'   $	��Top=�6B   $��
65,168,0,0q�6Z   $
��Bold"�6n   $��14(�6�   �� 5      -   5         ��Name$ 	yearUnder��5       �� 
IsEditable .  $
��Left=�6A   $	��Top=�6\   $	��120��6t   $��108,169,0,0q�6�   �� 5      $
��Year��6   $
��Left=�6'   $	��Top=�6B   $��
65,235,0,0q�6Z   $
��Bold"�6n   $��14(�6�   �� 5      -   5        $ yearPost��5       .  $
��Left=�6@   $	��Top=�6[   $��82��6s   $��108,236,0,0q�6~   �� 5      -	   5        $ yearExpected��5       .  $
��Left=�6D   $	��Top=�6_   $	��116��6w   $��207,236,-15,0q�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Expected Year��6�   �� 5       $��Profile��6   $
��Left=�6*   $	��Top=�6E   $��4,3,0,0q�6]   $
��Bold"�6n   $��10(�6�   5!      5"      )  #MaterialDesignThemes.Wpf.DialogHost  5#   
   -
   5           DialogContent 5%      �� 5&      $��16q�6   .+�5'      �� -   5        $ 	subjectTB��5'   �    �� DisplayMemberPath$
 name��6n    . $��0 8 0 0q�6�   $��Stretch=�6�   $ Subject Name��6�   ��6M   �� *
subjects+6�   �� 5(      -   5        $ typeCB��5(   �   $ classification��6G   $��0 8 0 0q�6j   $��Stretch=�6{   $ Subject Type��6�   ��6   �� *Classifications+6�   �� 5)      -   5        	 ��Name$	 delete��5)      �� 5*      
 �� Orientation$
 
Horizontal=�6!   $��Right=�6:   .+�5+      �� -   5        $ Accept��5+   !     MaterialDesignFlatButton#��[ 61    �� 	IsDefault . $��0 8 8 0q�5-   )   $2��,materialDesign:DialogHost.CloseDialogCommand��5.   )   .��5/   6   ADD51      �� 52      -   5        #��[ 52   !    �� IsCancel . $��0 8 8 0q�54   )   $2��,materialDesign:DialogHost.CloseDialogCommand��55   )   .��56   6   CANCEL58      59      5:      .��5>        $��	185,5,5,5q�6"   $
��auto��65   $��Stretch=�6C   $��Stretch=�6a   $
��auto��6}   .��5?      � .+�5@      &   System.Windows.Controls.DataGrid  -   5          Name$ dg��5@   �      CanUserAddRows .     CanUserReorderColumns .     AutoGenerateColumns .  $
��auto��6�   $
��auto��6�   $��Stretch=�6�   $��Stretch=�6�     6   �� *specificLoads+��6z   ��    Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Subject��6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *subject.name+6R     5C      $ Classification��6k    61   �� *'%subject.classification.classification+6k   5E      '	  !MaterialDesignThemes.Wpf.PopupBox	  5F       - )MaterialDesignMultiFloatingActionPopupBox#��[ 6.    	  PlacementMode$ TopAndAlignCentres=�5G   *   $��45��6M   $��44��6X    ^� 	Placement$ Right=�5H   *   $��	0,0,10,10q�6K   $��Right=�5I   *   $��Bottom=�6F    	  PopupContent. 5J      �� .+�5K      �� -   5        $ btnAdd��5K   %      OpenDialogCommand#��Z 6J    + 'MaterialDesignFloatingActionLightButton#���  6�    � ToolTip$	 Add��6�   $ Right=�6�   $��35��6�   $��34��6  $��	0,0,10,10q�6  $��30(�6&  $
��Bold"�64  .��5L   "   '
  !MaterialDesignThemes.Wpf.PackIcon
  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ LibraryPlus=�6:   $��20��6M   $��20��6X   5M      �� 5N      -   5        $ btnEdit��5N   %   #��Z 66   #���  6�   $
 Edit��6�   $ Right=�6�   $��35��6�   $��34��6
  $��	0,0,10,10q�6  $��30(�6)  $
��Bold"�67  .��5O   "   
  $ Pencil=�6:   $��20��6H   $��20��6S   5P      �� 5Q      -   5        $ 	btnDelete��5Q   %   #��Z 6P   #���  6�   $ Delete��6�   $ Right=�6�   $��35��6  $��34��6  $��	0,0,10,10q�6  $��30(�6/  $
��Bold"�6=  .��5R   "   
  $ Delete=�6:   $��20��6H   $��20��6S   5S      5T      5U      5V      5W      5X      5Y      5Z      