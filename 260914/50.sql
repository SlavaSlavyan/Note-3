SELECT DISTINCT o.battle
FROM Outcomes o
JOIN Ships s on s.name = o.ship
WHERE s.class = 'Kongo'