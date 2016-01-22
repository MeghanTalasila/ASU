<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page isELIgnored="false" %>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Reason for that Mood</title>
</head>
<body>
I am feeling: ${ mood.feeling }.
Because ${ mood.reason }.
</body>
</html>