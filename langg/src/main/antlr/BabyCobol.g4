grammar BabyCobol;
bacoheader      : LINEMARKER 'MAIN DIV' ;
bacoprogramid   : LINEMARKER 'PROGRAM ID ' PROGRAMID ;
bacoint         : INT ;
bacosepint      : (', ' bacoint)+ ;
bacoaddition    : LINEMARKER 'ADD ' bacosepint ;
bacosubtraction : LINEMARKER 'SUBTRACT ' bacosepint ;
bacofin         : LINEMARKER 'FIN' ;
bacomain        : bacoheader bacoprogramid (bacoaddition |
                  bacosubtraction)* bacofin ;
LINEMARKER      : 'X' ;
PROGRAMID       : [a-z]+ ;
INT             : [0-9]+ ;
WS              : [ \t\r\n]+ -> skip ;