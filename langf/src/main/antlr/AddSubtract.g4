grammar AddSubtract;
add      : 'first += '(myint+) ;
subtract : 'first -= '(myint+) ;
myint    : INT ;
INT      : [0-9]+ ;
WS       : [ \t\r\n]+ -> skip ;