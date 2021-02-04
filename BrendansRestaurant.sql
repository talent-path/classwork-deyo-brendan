--
-- PostgreSQL database dump
--

-- Dumped from database version 13.1
-- Dumped by pg_dump version 13.1

-- Started on 2021-02-03 18:06:09 EST

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "Restaurant";
--
-- TOC entry 3346 (class 1262 OID 16439)
-- Name: Restaurant; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "Restaurant" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'C';


ALTER DATABASE "Restaurant" OWNER TO "postgres";

\connect "Restaurant"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = "heap";

--
-- TOC entry 203 (class 1259 OID 16450)
-- Name: Dishes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Dishes" (
    "dishID" integer NOT NULL,
    "name" character varying(50) NOT NULL
);


ALTER TABLE "public"."Dishes" OWNER TO "postgres";

--
-- TOC entry 202 (class 1259 OID 16448)
-- Name: Dishes_dishID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Dishes_dishID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Dishes_dishID_seq" OWNER TO "postgres";

--
-- TOC entry 3347 (class 0 OID 0)
-- Dependencies: 202
-- Name: Dishes_dishID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Dishes_dishID_seq" OWNED BY "public"."Dishes"."dishID";


--
-- TOC entry 201 (class 1259 OID 16442)
-- Name: Ingredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Ingredients" (
    "ingredientID" integer NOT NULL,
    "name" character varying(50) NOT NULL,
    "stock" numeric(5,2),
    "units" character varying(10),
    "isOrganic" boolean
);


ALTER TABLE "public"."Ingredients" OWNER TO "postgres";

--
-- TOC entry 200 (class 1259 OID 16440)
-- Name: Ingredients_ingredientID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Ingredients_ingredientID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Ingredients_ingredientID_seq" OWNER TO "postgres";

--
-- TOC entry 3348 (class 0 OID 0)
-- Dependencies: 200
-- Name: Ingredients_ingredientID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Ingredients_ingredientID_seq" OWNED BY "public"."Ingredients"."ingredientID";


--
-- TOC entry 216 (class 1259 OID 16539)
-- Name: MenuDishes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."MenuDishes" (
    "menuID" integer NOT NULL,
    "dishID" integer NOT NULL,
    "price" numeric NOT NULL
);


ALTER TABLE "public"."MenuDishes" OWNER TO "postgres";

--
-- TOC entry 207 (class 1259 OID 16474)
-- Name: Menus; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Menus" (
    "menuID" integer NOT NULL,
    "name" character varying(20) NOT NULL
);


ALTER TABLE "public"."Menus" OWNER TO "postgres";

--
-- TOC entry 206 (class 1259 OID 16472)
-- Name: Menus_menuID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Menus_menuID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Menus_menuID_seq" OWNER TO "postgres";

--
-- TOC entry 3349 (class 0 OID 0)
-- Dependencies: 206
-- Name: Menus_menuID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Menus_menuID_seq" OWNED BY "public"."Menus"."menuID";


--
-- TOC entry 217 (class 1259 OID 16557)
-- Name: OrderDishes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."OrderDishes" (
    "orderID" integer NOT NULL,
    "menuID" integer,
    "dishID" integer,
    "quantity" numeric(5,2) NOT NULL
);


ALTER TABLE "public"."OrderDishes" OWNER TO "postgres";

--
-- TOC entry 213 (class 1259 OID 16498)
-- Name: Orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Orders" (
    "orderID" integer NOT NULL,
    "tabletopID" integer NOT NULL
);


ALTER TABLE "public"."Orders" OWNER TO "postgres";

--
-- TOC entry 212 (class 1259 OID 16496)
-- Name: Orders_orderID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Orders_orderID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Orders_orderID_seq" OWNER TO "postgres";

--
-- TOC entry 3350 (class 0 OID 0)
-- Dependencies: 212
-- Name: Orders_orderID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Orders_orderID_seq" OWNED BY "public"."Orders"."orderID";


--
-- TOC entry 214 (class 1259 OID 16509)
-- Name: RecipeIngredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."RecipeIngredients" (
    "recipeID" integer NOT NULL,
    "ingredientID" integer NOT NULL,
    "quantity" numeric(5,2) NOT NULL,
    "unit" character varying(5) NOT NULL
);


ALTER TABLE "public"."RecipeIngredients" OWNER TO "postgres";

--
-- TOC entry 205 (class 1259 OID 16458)
-- Name: Recipes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Recipes" (
    "recipeID" integer NOT NULL,
    "dishID" integer NOT NULL,
    "name" character varying(100) NOT NULL,
    "instructions" "text" NOT NULL
);


ALTER TABLE "public"."Recipes" OWNER TO "postgres";

--
-- TOC entry 204 (class 1259 OID 16456)
-- Name: Recipes_recipeID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Recipes_recipeID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Recipes_recipeID_seq" OWNER TO "postgres";

--
-- TOC entry 3351 (class 0 OID 0)
-- Dependencies: 204
-- Name: Recipes_recipeID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Recipes_recipeID_seq" OWNED BY "public"."Recipes"."recipeID";


--
-- TOC entry 215 (class 1259 OID 16524)
-- Name: SupplierIngredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."SupplierIngredients" (
    "supplierID" integer NOT NULL,
    "ingredientID" integer NOT NULL,
    "qtyAvailable" numeric(5,2),
    "units" character varying(10),
    "unitCost" numeric(5,2) NOT NULL
);


ALTER TABLE "public"."SupplierIngredients" OWNER TO "postgres";

--
-- TOC entry 209 (class 1259 OID 16482)
-- Name: Suppliers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Suppliers" (
    "supplierID" integer NOT NULL,
    "name" character varying(50) NOT NULL
);


ALTER TABLE "public"."Suppliers" OWNER TO "postgres";

--
-- TOC entry 208 (class 1259 OID 16480)
-- Name: Suppliers_supplierID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Suppliers_supplierID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Suppliers_supplierID_seq" OWNER TO "postgres";

--
-- TOC entry 3352 (class 0 OID 0)
-- Dependencies: 208
-- Name: Suppliers_supplierID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Suppliers_supplierID_seq" OWNED BY "public"."Suppliers"."supplierID";


--
-- TOC entry 211 (class 1259 OID 16490)
-- Name: Tabletops; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Tabletops" (
    "tabletopID" integer NOT NULL,
    "seatCount" smallint
);


ALTER TABLE "public"."Tabletops" OWNER TO "postgres";

--
-- TOC entry 210 (class 1259 OID 16488)
-- Name: Tabletops_tabletopID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Tabletops_tabletopID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Tabletops_tabletopID_seq" OWNER TO "postgres";

--
-- TOC entry 3353 (class 0 OID 0)
-- Dependencies: 210
-- Name: Tabletops_tabletopID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Tabletops_tabletopID_seq" OWNED BY "public"."Tabletops"."tabletopID";


--
-- TOC entry 3172 (class 2604 OID 16453)
-- Name: Dishes dishID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Dishes" ALTER COLUMN "dishID" SET DEFAULT "nextval"('"public"."Dishes_dishID_seq"'::"regclass");


--
-- TOC entry 3171 (class 2604 OID 16445)
-- Name: Ingredients ingredientID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Ingredients" ALTER COLUMN "ingredientID" SET DEFAULT "nextval"('"public"."Ingredients_ingredientID_seq"'::"regclass");


--
-- TOC entry 3174 (class 2604 OID 16477)
-- Name: Menus menuID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Menus" ALTER COLUMN "menuID" SET DEFAULT "nextval"('"public"."Menus_menuID_seq"'::"regclass");


--
-- TOC entry 3177 (class 2604 OID 16501)
-- Name: Orders orderID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Orders" ALTER COLUMN "orderID" SET DEFAULT "nextval"('"public"."Orders_orderID_seq"'::"regclass");


--
-- TOC entry 3173 (class 2604 OID 16461)
-- Name: Recipes recipeID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Recipes" ALTER COLUMN "recipeID" SET DEFAULT "nextval"('"public"."Recipes_recipeID_seq"'::"regclass");


--
-- TOC entry 3175 (class 2604 OID 16485)
-- Name: Suppliers supplierID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Suppliers" ALTER COLUMN "supplierID" SET DEFAULT "nextval"('"public"."Suppliers_supplierID_seq"'::"regclass");


--
-- TOC entry 3176 (class 2604 OID 16493)
-- Name: Tabletops tabletopID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Tabletops" ALTER COLUMN "tabletopID" SET DEFAULT "nextval"('"public"."Tabletops_tabletopID_seq"'::"regclass");


--
-- TOC entry 3181 (class 2606 OID 16455)
-- Name: Dishes Dishes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Dishes"
    ADD CONSTRAINT "Dishes_pkey" PRIMARY KEY ("dishID");


--
-- TOC entry 3179 (class 2606 OID 16447)
-- Name: Ingredients Ingredients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Ingredients"
    ADD CONSTRAINT "Ingredients_pkey" PRIMARY KEY ("ingredientID");


--
-- TOC entry 3197 (class 2606 OID 16546)
-- Name: MenuDishes MenuDishes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."MenuDishes"
    ADD CONSTRAINT "MenuDishes_pkey" PRIMARY KEY ("menuID", "dishID");


--
-- TOC entry 3185 (class 2606 OID 16479)
-- Name: Menus Menus_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Menus"
    ADD CONSTRAINT "Menus_pkey" PRIMARY KEY ("menuID");


--
-- TOC entry 3199 (class 2606 OID 16561)
-- Name: OrderDishes OrderDishes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."OrderDishes"
    ADD CONSTRAINT "OrderDishes_pkey" PRIMARY KEY ("orderID");


--
-- TOC entry 3191 (class 2606 OID 16503)
-- Name: Orders Orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Orders"
    ADD CONSTRAINT "Orders_pkey" PRIMARY KEY ("orderID");


--
-- TOC entry 3193 (class 2606 OID 16513)
-- Name: RecipeIngredients RecipeIngredients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."RecipeIngredients"
    ADD CONSTRAINT "RecipeIngredients_pkey" PRIMARY KEY ("recipeID", "ingredientID");


--
-- TOC entry 3183 (class 2606 OID 16466)
-- Name: Recipes Recipes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Recipes"
    ADD CONSTRAINT "Recipes_pkey" PRIMARY KEY ("recipeID");


--
-- TOC entry 3195 (class 2606 OID 16528)
-- Name: SupplierIngredients SupplierIngredients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."SupplierIngredients"
    ADD CONSTRAINT "SupplierIngredients_pkey" PRIMARY KEY ("supplierID", "ingredientID");


--
-- TOC entry 3187 (class 2606 OID 16487)
-- Name: Suppliers Suppliers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Suppliers"
    ADD CONSTRAINT "Suppliers_pkey" PRIMARY KEY ("supplierID");


--
-- TOC entry 3189 (class 2606 OID 16495)
-- Name: Tabletops Tabletops_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Tabletops"
    ADD CONSTRAINT "Tabletops_pkey" PRIMARY KEY ("tabletopID");


--
-- TOC entry 3207 (class 2606 OID 16552)
-- Name: MenuDishes MenuDishes_dishID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."MenuDishes"
    ADD CONSTRAINT "MenuDishes_dishID_fkey" FOREIGN KEY ("dishID") REFERENCES "public"."Dishes"("dishID");


--
-- TOC entry 3206 (class 2606 OID 16547)
-- Name: MenuDishes MenuDishes_menuID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."MenuDishes"
    ADD CONSTRAINT "MenuDishes_menuID_fkey" FOREIGN KEY ("menuID") REFERENCES "public"."Menus"("menuID");


--
-- TOC entry 3210 (class 2606 OID 16572)
-- Name: OrderDishes OrderDishes_dishID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."OrderDishes"
    ADD CONSTRAINT "OrderDishes_dishID_fkey" FOREIGN KEY ("dishID") REFERENCES "public"."Dishes"("dishID");


--
-- TOC entry 3209 (class 2606 OID 16567)
-- Name: OrderDishes OrderDishes_menuID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."OrderDishes"
    ADD CONSTRAINT "OrderDishes_menuID_fkey" FOREIGN KEY ("menuID") REFERENCES "public"."Menus"("menuID");


--
-- TOC entry 3208 (class 2606 OID 16562)
-- Name: OrderDishes OrderDishes_orderID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."OrderDishes"
    ADD CONSTRAINT "OrderDishes_orderID_fkey" FOREIGN KEY ("orderID") REFERENCES "public"."Orders"("orderID");


--
-- TOC entry 3201 (class 2606 OID 16504)
-- Name: Orders Orders_tabletopID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Orders"
    ADD CONSTRAINT "Orders_tabletopID_fkey" FOREIGN KEY ("tabletopID") REFERENCES "public"."Tabletops"("tabletopID");


--
-- TOC entry 3203 (class 2606 OID 16519)
-- Name: RecipeIngredients RecipeIngredients_ingredientID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."RecipeIngredients"
    ADD CONSTRAINT "RecipeIngredients_ingredientID_fkey" FOREIGN KEY ("ingredientID") REFERENCES "public"."Ingredients"("ingredientID");


--
-- TOC entry 3202 (class 2606 OID 16514)
-- Name: RecipeIngredients RecipeIngredients_recipeID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."RecipeIngredients"
    ADD CONSTRAINT "RecipeIngredients_recipeID_fkey" FOREIGN KEY ("recipeID") REFERENCES "public"."Recipes"("recipeID");


--
-- TOC entry 3200 (class 2606 OID 16467)
-- Name: Recipes Recipes_dishID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Recipes"
    ADD CONSTRAINT "Recipes_dishID_fkey" FOREIGN KEY ("dishID") REFERENCES "public"."Dishes"("dishID");


--
-- TOC entry 3205 (class 2606 OID 16534)
-- Name: SupplierIngredients SupplierIngredients_ingredientID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."SupplierIngredients"
    ADD CONSTRAINT "SupplierIngredients_ingredientID_fkey" FOREIGN KEY ("ingredientID") REFERENCES "public"."Ingredients"("ingredientID");


--
-- TOC entry 3204 (class 2606 OID 16529)
-- Name: SupplierIngredients SupplierIngredients_supplierID_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."SupplierIngredients"
    ADD CONSTRAINT "SupplierIngredients_supplierID_fkey" FOREIGN KEY ("supplierID") REFERENCES "public"."Suppliers"("supplierID");


-- Completed on 2021-02-03 18:06:09 EST

--
-- PostgreSQL database dump complete
--

