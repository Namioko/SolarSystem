   M S B A M L   `   `   `  ����  Visualization    Visualization.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  
mainWindow��5   	    � Title$&  Solar System Epic Simulator 2000��5   	   $
��5200��62   $
��4000��6@    � WindowState$ 	Maximized=�6M    � WindowStartupLocation$ Manual=�6e    � Icon$ Resources/icon.png��6�   .��5      � -   5         �Name$ 	spaceGrid��5      ��5	   
   �� 5
       �� ImageSource$ Resources/space.png��6   .+�5   
   �� -   5         ��Name$ spaceScroll��5      $��Visible=�6,   $��Visible=�6R    � OverridesDefaultStyle . .��5      �� -   5        	 ��Name$	 spaceCanvas��5      $
��5200��6*   
 � IsSharedSizeScope
 . $
��4000��6V   ��. 6c   5      �� 5   
   -   5         ��Name$ menuGroupBox��5      $�� ��6)   $
��Left=�63   $��	49,50,0,0q�6N   $	��Top=�6a   $	��475��6y   $	��200��6�   .��5      � $
��Left=�6   $	��200��6.   $��
0,0,-12,-3q�6:   .+�5      �� -   5         ��Name$ startButton��5      $��Start��6.   $��Right=�6>   $	��Top=�6Z   $��75��6r   $��	0,20,65,0q�6�   �� 5      -   5        $ pauseButton��5      $��Pause��6.   $��Right=�6>   $��	0,57,65,0q�6Z   $	��Top=�6m   $��75��6�   6�   �� 5      -   5         ��Name$ secondsSlider��5      $��Right=�60   $��
0,155,40,0q�6L   $	��Top=�6`   $	��120��6x    � SmallChange$
 0.01Q�6�    J� SnapsToDevicePixels .  J� RenderTransformOrigin$ 0.5,0.5&�6�    � Minimum$	 0.5Q�6�    �� TickPlacement$ BottomRight=�6   �� TickFrequency$
 0.01Q�6   �� AutoToolTipPlacement$ BottomRight=�64   �� AutoToolTipPrecision$ 2��6W   � Maximum$ 5Q�6p  �� 5      -	   5        $ 
zoomButton��5      $��Zoom out��6-   $��Right=�6@   $��
0,205,80,0q�6\   $	��Top=�6p   6�   �� 5      -
   5         ��Name$ labelSlider��5      $��Seconds per month:��6-   $
��Left=�6J   $��
40,130,0,0q�6e   $	��Top=�6y   $	��118��6�   
�������6�   �� 5      -   5         ��Name$ showTrajectoryCheckBox��5      $
��Left=�6;   $��
40,428,0,0q�6V   $	��Top=�6j   $	��150��6�    d� 	IsChecked$
 TrueY�6�   
�������$��37��6  
������� � ToolTip$! Is changeable only on start��6'  ���	#FFA2A2A2.��5      �� $��40��6    �� 5       �� TextWrapping$
 Wrap=�6%   $��Show trajectory��5   %   $��22��6<   $��98��6H   $! Is changeable only on start��6S   5      5      �� 5      -   5        $ cometGroupBox��5      $��Comet parameters��62   $
��Left=�6L   $��
10,235,0,0q�6g   $	��Top=�6{   $	��178��6�   $	��170��6�   
�������.��5      � $
��Left=�6   $	��163��66   $��
10,10,-2,0q�6C   $	��Top=�6W   $	��150��6o   .+�5      �� -   5        $ 
massSlider��5   !   $
��Left=�65   $��	20,35,0,0q�6P   $	��Top=�6c   $	��105��6{   $	 0.1Q�6�   $	 0.5Q�6�   $ BottomRight=�6�   $	 0.1Q�6�   $ BottomRight=�6�   $ 10Q�6!  $! Is changeable only on start��6.  �� 5      -   5        $ 	massLabel��5       $��Mass (*10^14 kg)��63   $
��Left=�6N   $��	20,10,0,0q�6i   $	��Top=�6|   $	��105��6�   
�������$! Is changeable only on start��6�   �� 5       -   5        $ 
speedLabel��5        $��Initial speed (yrs/turn)��64   $
��Left=�6W   $��	10,85,0,0q�6r   $	��Top=�6�   $	��130��6�   
�������$! Is changeable only on start��6�   �� 5!      -   5        $ speedSlider��5!   !   $
��Left=�66   $��
20,111,0,0q�6Q   $	��Top=�6e   $	��105��6}   $	 0.1Q�6�   $ 50Q�6�   $ BottomRight=�6�   $	 0.1Q�6  $ BottomRight=�6  $	 100Q�68  $! Is changeable only on start��6F  5"      5#      �� 5$      -   5        $ resetButton��5$      $��Reset��6.   $
��Left=�6>   $��	60,95,0,0q�6Y   $	��Top=�6l   $��75��6�   6�   5%      5&      �� 5'   
   -   5        $ legendGroupBox��5'      $�� ��6+   $��Right=�65   $��	0,50,70,0q�6Q   $	��Top=�6d   $	��850��6|   $	��250��6�   .��5(      � -   5        $ 
legendGrid��5(      $
��Left=�6'   $	��830��6B   $	��Top=�6O   $	��230��6g   $��0,0,0,-2q�6s   6�   5)      �� 5*   
   -   5        $ openLegendButton��5*      $��<<��6+   $��Right=�6>   $��
0,450,30,0q�6Z   $	��Top=�6n   $��25��6�   $ Open Legend��6�   �� 5+   
   -   5        $ closeLegendButton��5+      $��>>��6,   $��Right=�6?   $��0,450,330,0q�6[   $	��Top=�6p   $��25��6�   $ Close Legend��6�   5,      5-      