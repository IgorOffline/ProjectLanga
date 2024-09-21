grammar BabyCobol;
bacoheader      : LINEMARKER 'MAIN DIV' ;
bacoprogramid   : LINEMARKER 'PROGRAM ID ' PROGRAMID ;
bacovar         : VARNAME ;
bacoint         : INT ;
bacosepint      : (', ' bacoint)+ ;
bacoaddition    : LINEMARKER bacovar ', ADD ' bacosepint ;
bacosubtraction : LINEMARKER bacovar ', SUBTRACT ' bacosepint ;
bacofin         : LINEMARKER 'FIN' ;
bacomain        : bacoheader bacoprogramid (bacoaddition |
                  bacosubtraction)* bacofin ;
LINEMARKER      : 'X' ;
PROGRAMID       : [a-z]+ ;
VARNAME         : [a-zA-Z0-9\-]+ ;
INT             : [0-9]+ ;
WS              : [ \t\r\n]+ -> skip ;