﻿using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;

namespace FinesaPosta
{
    /* Naziv metapodatka/Opis/Format zapisa
1. NazivDobavitelja/Naziv dobavitelja/String (255)
2. SifraDobavitelja/Šifra partnerja/String (50)
3. DavcnaStevilkaDobavitelja/Davčna številka partnerja/String (11)
4. StevilkaRacuna/Številka računa/String (50)
5. DatumIzdajeRacuna/Datum izdaje racuna/Date Time
6. Leto/Leto/String (4)
     * 
     * <?xml version="1.0" encoding="utf-8"?>
<LDoc version="1.0" xmlns="http://schemas.posta.si/earchive/sendldoc.xsd">
<PDocs>
<PDoc......
</PDoc>
</PDocs>
<Label>Stat test A</Label>
<MetaPodatek1>bla bla</MetaPodatek1>
 <DavcnaStevilka>
</LDoc>
*/

    [Verb("send", HelpText = "Sends files with some metadata to storage.")]
    class SendLDocOptions
    {
        [Option('f', "files", Required = true, Min=1, HelpText = "Input files to be sent.")]
        public IEnumerable<string> InputFiles { get; set; }

        [Option('n', "naziv", Required = true, HelpText = "Naziv dokumenta.")]
        public string Naziv { get; set; }

        
        [Option('k', "koda", Required = true, HelpText = "Koda dokumenta.")]
        public string Koda { get; set; }
        
        [Option('d', "nazivdobavitelja", Required = true, HelpText = "Naziv dobavitelja.")]
        public string NazivDobavitelja { get; set; }
        
        [Option('s', "sifradobavitelja", Required = true, HelpText = "Šifra dobavitelja.")]
        public string SifraDobavitelja { get; set; }

        [Option('l', "leto", Required = true, HelpText = "Leto.")]
        public int Leto { get; set; }

        [Option('v', "davcnastevilkadobavitelja", Required = true, HelpText = "Davčna številka dobavitelja" )]
        public string DavcnaStevilkaDobavitelja { get; set; }

        [Option('r', "stevilkaracuna", Required = true, HelpText = "Šifra dobavitelja.")]
        public string StevilkaRacuna { get; set; }

        [Option('i', "datumizdajeracuna", Required = true, HelpText = "Datum izdaje računa.")]
        public DateTime DatumIzdajeRacuna  { get; set; }

        [Option('t', "debug", Default= false, HelpText = "Prikaži XML pred pošiljanjem.")]
        public bool Debug { get; set; }
    }

    [Verb("get", HelpText = "Gets file metadata. Not implemented yet.")]
    class GetLDocOptions
    {
        [Option('g', "guid", Required = true, HelpText = "GUID of the file.")]
        public string Guid { get; set; }
    }

    [Verb("schema", HelpText = "Gets schema for sending LDOC (which includes custom metadata fields.")]
    class GetSendLDocSchemaOptions
    {
    }

    [Verb("sendfromcsv", HelpText = "Sends multiple files with some metadata to storage. List of files is read from CSV")]
    class SendLDocCSVOptions
    {
        [Option('f', "file", Required = true, HelpText = "CSV file with list of documents.")]
        public string CsvListFileName { get; set; }

        [Option('t', "debug", Default = false, HelpText = "Prikaži XML pred pošiljanjem.")]
        public bool Debug { get; set; }
    }
}