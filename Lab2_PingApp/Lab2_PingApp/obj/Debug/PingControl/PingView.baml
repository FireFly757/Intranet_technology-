   M S B A M L   `   `   `  ����G  CLab2_PingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Lab2_PingApp.PingControlLab2_PingApp.PingControl  5          Lab2_PingApp.PingView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Lab2_PingApp.PingControl     5      $��15(�5      $��Medium"�5	      .��5      � 
�������  � ColumnDefinitions  5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5       $��20 �6   .+�5$   
   �� $��1��6   $��1��6!   $��	Address: ��61   �� 5%   
   $��1��6   $��2��6    ��60   �� *	Address+�� 5'   
   $��2��6   $��1��6!   $��Buffer size: ��61   �� 5(   
   $��2��6   $��2��6   ��60   �� *
BufferSize+�� 5*   
   $��3��6   $��1��6!   $��Time To Life: ��61   �� 5+   
   $��3��6   $��2��6    ��60   �� *
TimeToLife+�� 5-   
   $��4��6   $��1��6!   $��Type of Service: ��61   �� 5.   
   $��4��6   $��2��6    ��60   �� *TypeOfService+�� 50   
   $��5��6   $��1��6!   $��Number of requests: ��61   �� 51   
   $��5��6   $��2��6    ��60   �� *RequestsNumber+�� 53   
   $��6��6   $��1��6!   $��	Timeout: ��61   �� 54   
   $��6��6   $��2��6    ��60   �� *	Timeout+�� 56   
   $��7��6   $��1��6    $��2��60   $��Package Fragmentation��57      $��10q�63    d� 	IsChecked 56   E   �� *IsFragmentation+57   3   �� 58   
   -   5        $��manualStopping��58   D   $��8��6   $��1��6    $��2��60   $��Manual stop sending��59      $��10q�61    58   Z   �� *IsManualStopSending+59   1   �� 5;   
   $��9��6   $��1��6   $��2��6.   $��10q�6B   $��Request��5<      ��5=      ��  �� Path$ SendRequestCommand��� 5?   
   $��9��6   $��4��6   $��10q�6/   
�������$��Stop requests��5A      {�5?   ;   ��  �� ElementName$ manualStopping��$ 	IsChecked���5B      �� $  StopSendingRequestsCommand��� 5D   
   $��10��6   $��1��6"   $��4��62   ��6F   �� $ Requests� �� View 5E      �� 5F      .P�5G      �� $��
IP address��6%    �� Width$
 Auto��6i    �� DisplayMemberBinding 69   �� $ 	IpAddress�6i   �� 5H      $
��Time��6%   $
 Auto��6g    63   �� $ RoadtripTime�6g   5I      5K      � 5N   
   $��1��6   $��4��6   $��7��6,   
����ح�  5O      �� 5P      $
��Auto �6#   �� 5Q      $��* �6#    5S      �� 5T      $
��Auto �6    �� 5U      $
��Auto �6    �� 5V      $
��Auto �6    �� 5W      $
��Auto �6    �� 5X      $
��Auto �6    �� 5Y      $
��Auto �6    �� 5Z      $
��Auto �6    �� 5[      $
��Auto �6    �� 5\      $
��Auto �6    �� 5]      $
��Auto �6    �� 5^      $
��Auto �6    .+�5a      �� $��0��6   $��0��6%   $��2��65   $��
Statistics��6I   $��18(�6[   $��	ExtraBold"�6i   $��Center=�6�   �� 5b      $��1��6   $��0��6%   $��2��66   $��Packages��6J   $
��Bold"�6Z   $��Center=�6l   �� 5d      $��2��6   $��0��6%   $��Sent: ��65   �� 5e      $��2��6   $��1��6&   ��66   �� *SentPackages+�� 5g      $��3��6   $��0��6%   $��
Received: ��65   �� 5h      $��3��6   $��1��6&   ��66   �� *ReceivedPackages+�� 5j      $��4��6   $��0��6%   $��Lost: ��65   �� 5k      $��4��6   $��1��6&   ��66   �� *LostPackages+�� 5m      $��5��6   $��0��6%   $��	Lost(%): ��65   �� 5n      $��5��6   $��1��6&   ��66   �� *LostInPercent+�� 5p      $��6��6   $��0��6%   $��2��66   $��Transmission time��6J   $
��Bold"�6c   $��Center=�6u   �� 5s      $��7��6   $��0��6%   $��	Minimum: ��65   �� 5t      $��7��6   $��1��6&   ��66   �� *	MinTime+�� 5v      $��8��6   $��0��6%   $��	Maximum: ��65   �� 5w      $��8��6   $��1��6&   ��66   �� *	MaxTime+�� 5y      $��9��6   $��0��6%   $��	Average: ��65   �� 5z      $��9��6   $��1��6&   ��66   �� *AverageTime+5{      5|      5}      