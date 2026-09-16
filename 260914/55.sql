SELECT c.class, MIN(s.launched)
FROM Classes c
LEFT JOIN Ships s ON c.class = s.class
GROUP BY c.class
