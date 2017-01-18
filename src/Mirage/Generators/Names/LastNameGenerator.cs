﻿/*
Copyright 2017 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using BigBook;
using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;
using System;
using System.Text;

namespace Mirage.Generators
{
    /// <summary>
    /// LastName Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public class LastNameAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LastNameAttribute()
            : base("", "")
        {
        }

        private readonly string[] LastNames = { "SMITH", "JOHNSON", "WILLIAMS", "JONES", "BROWN", "DAVIS", "MILLER", "WILSON", "MOORE", "TAYLOR", "ANDERSON", "THOMAS", "JACKSON", "WHITE", "HARRIS", "MARTIN", "THOMPSON", "GARCIA", "MARTINEZ", "ROBINSON", "CLARK", "RODRIGUEZ", "LEWIS", "LEE", "WALKER", "HALL", "ALLEN", "YOUNG", "HERNANDEZ", "KING", "WRIGHT", "LOPEZ", "HILL", "SCOTT", "GREEN", "ADAMS", "BAKER", "GONZALEZ", "NELSON", "CARTER", "MITCHELL", "PEREZ", "ROBERTS", "TURNER", "PHILLIPS", "CAMPBELL", "PARKER", "EVANS", "EDWARDS", "COLLINS", "STEWART", "SANCHEZ", "MORRIS", "ROGERS", "REED", "COOK", "MORGAN", "BELL", "MURPHY", "BAILEY", "RIVERA", "COOPER", "RICHARDSON", "COX", "HOWARD", "WARD", "TORRES", "PETERSON", "GRAY", "RAMIREZ", "JAMES", "WATSON", "BROOKS", "KELLY", "SANDERS", "PRICE", "BENNETT", "WOOD", "BARNES", "ROSS", "HENDERSON", "COLEMAN", "JENKINS", "PERRY", "POWELL", "LONG", "PATTERSON", "HUGHES", "FLORES", "WASHINGTON", "BUTLER", "SIMMONS", "FOSTER", "GONZALES", "BRYANT", "ALEXANDER", "RUSSELL", "GRIFFIN", "DIAZ", "HAYES", "MYERS", "FORD", "HAMILTON", "GRAHAM", "SULLIVAN", "WALLACE", "WOODS", "COLE", "WEST", "JORDAN", "OWENS", "REYNOLDS", "FISHER", "ELLIS", "HARRISON", "GIBSON", "MCDONALD", "CRUZ", "MARSHALL", "ORTIZ", "GOMEZ", "MURRAY", "FREEMAN", "WELLS", "WEBB", "SIMPSON", "STEVENS", "TUCKER", "PORTER", "HUNTER", "HICKS", "CRAWFORD", "HENRY", "BOYD", "MASON", "MORALES", "KENNEDY", "WARREN", "DIXON", "RAMOS", "REYES", "BURNS", "GORDON", "SHAW", "HOLMES", "RICE", "ROBERTSON", "HUNT", "BLACK", "DANIELS", "PALMER", "MILLS", "NICHOLS", "GRANT", "KNIGHT", "FERGUSON", "ROSE", "STONE", "HAWKINS", "DUNN", "PERKINS", "HUDSON", "SPENCER", "GARDNER", "STEPHENS", "PAYNE", "PIERCE", "BERRY", "MATTHEWS", "ARNOLD", "WAGNER", "WILLIS", "RAY", "WATKINS", "OLSON", "CARROLL", "DUNCAN", "SNYDER", "HART", "CUNNINGHAM", "BRADLEY", "LANE", "ANDREWS", "RUIZ", "HARPER", "FOX", "RILEY", "ARMSTRONG", "CARPENTER", "WEAVER", "GREENE", "LAWRENCE", "ELLIOTT", "CHAVEZ", "SIMS", "AUSTIN", "PETERS", "KELLEY", "FRANKLIN", "LAWSON", "FIELDS", "GUTIERREZ", "RYAN", "SCHMIDT", "CARR", "VASQUEZ", "CASTILLO", "WHEELER", "CHAPMAN", "OLIVER", "MONTGOMERY", "RICHARDS", "WILLIAMSON", "JOHNSTON", "BANKS", "MEYER", "BISHOP", "MCCOY", "HOWELL", "ALVAREZ", "MORRISON", "HANSEN", "FERNANDEZ", "GARZA", "HARVEY", "LITTLE", "BURTON", "STANLEY", "NGUYEN", "GEORGE", "JACOBS", "REID", "KIM", "FULLER", "LYNCH", "DEAN", "GILBERT", "GARRETT", "ROMERO", "WELCH", "LARSON", "FRAZIER", "BURKE", "HANSON", "DAY", "MENDOZA", "MORENO", "BOWMAN", "MEDINA", "FOWLER", "BREWER", "HOFFMAN", "CARLSON", "SILVA", "PEARSON", "HOLLAND", "DOUGLAS", "FLEMING", "JENSEN", "VARGAS", "BYRD", "DAVIDSON", "HOPKINS", "MAY", "TERRY", "HERRERA", "WADE", "SOTO", "WALTERS", "CURTIS", "NEAL", "CALDWELL", "LOWE", "JENNINGS", "BARNETT", "GRAVES", "JIMENEZ", "HORTON", "SHELTON", "BARRETT", "OBRIEN", "CASTRO", "SUTTON", "GREGORY", "MCKINNEY", "LUCAS", "MILES", "CRAIG", "RODRIQUEZ", "CHAMBERS", "HOLT", "LAMBERT", "FLETCHER", "WATTS", "BATES", "HALE", "RHODES", "PENA", "BECK", "NEWMAN", "HAYNES", "MCDANIEL", "MENDEZ", "BUSH", "VAUGHN", "PARKS", "DAWSON", "SANTIAGO", "NORRIS", "HARDY", "LOVE", "STEELE", "CURRY", "POWERS", "SCHULTZ", "BARKER", "GUZMAN", "PAGE", "MUNOZ", "BALL", "KELLER", "CHANDLER", "WEBER", "LEONARD", "WALSH", "LYONS", "RAMSEY", "WOLFE", "SCHNEIDER", "MULLINS", "BENSON", "SHARP", "BOWEN", "DANIEL", "BARBER", "CUMMINGS", "HINES", "BALDWIN", "GRIFFITH", "VALDEZ", "HUBBARD", "SALAZAR", "REEVES", "WARNER", "STEVENSON", "BURGESS", "SANTOS", "TATE", "CROSS", "GARNER", "MANN", "MACK", "MOSS", "THORNTON", "DENNIS", "MCGEE", "FARMER", "DELGADO", "AGUILAR", "VEGA", "GLOVER", "MANNING", "COHEN", "HARMON", "RODGERS", "ROBBINS", "NEWTON", "TODD", "BLAIR", "HIGGINS", "INGRAM", "REESE", "CANNON", "STRICKLAND", "TOWNSEND", "POTTER", "GOODWIN", "WALTON", "ROWE", "HAMPTON", "ORTEGA", "PATTON", "SWANSON", "JOSEPH", "FRANCIS", "GOODMAN", "MALDONADO", "YATES", "BECKER", "ERICKSON", "HODGES", "RIOS", "CONNER", "ADKINS", "WEBSTER", "NORMAN", "MALONE", "HAMMOND", "FLOWERS", "COBB", "MOODY", "QUINN", "BLAKE", "MAXWELL", "POPE", "FLOYD", "OSBORNE", "PAUL", "MCCARTHY", "GUERRERO", "LINDSEY", "ESTRADA", "SANDOVAL", "GIBBS", "TYLER", "GROSS", "FITZGERALD", "STOKES", "DOYLE", "SHERMAN", "SAUNDERS", "WISE", "COLON", "GILL", "ALVARADO", "GREER", "PADILLA", "SIMON", "WATERS", "NUNEZ", "BALLARD", "SCHWARTZ", "MCBRIDE", "HOUSTON", "CHRISTENSEN", "KLEIN", "PRATT", "BRIGGS", "PARSONS", "MCLAUGHLIN", "ZIMMERMAN", "FRENCH", "BUCHANAN", "MORAN", "COPELAND", "ROY", "PITTMAN", "BRADY", "MCCORMICK", "HOLLOWAY", "BROCK", "POOLE", "FRANK", "LOGAN", "OWEN", "BASS", "MARSH", "DRAKE", "WONG", "JEFFERSON", "PARK", "MORTON", "ABBOTT", "SPARKS", "PATRICK", "NORTON", "HUFF", "CLAYTON", "MASSEY", "LLOYD", "FIGUEROA", "CARSON", "BOWERS", "ROBERSON", "BARTON", "TRAN", "LAMB", "HARRINGTON", "CASEY", "BOONE", "CORTEZ", "CLARKE", "MATHIS", "SINGLETON", "WILKINS", "CAIN", "BRYAN", "UNDERWOOD", "HOGAN", "MCKENZIE", "COLLIER", "LUNA", "PHELPS", "MCGUIRE", "ALLISON", "BRIDGES", "WILKERSON", "NASH", "SUMMERS" };

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return rand.Next(LastNames).ToLowerInvariant().ToString(StringCase.FirstCharacterUpperCase);
        }
    }
}