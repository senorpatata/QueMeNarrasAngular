﻿/*! 
* DevExtreme (Vector Map)
* Version: 15.2.5
* Build date: Jan 27, 2016
*
* Copyright (c) 2012 - 2016 Developer Express Inc. ALL RIGHTS RESERVED
* EULA: https://www.devexpress.com/Support/EULAs/DevExtreme.xml
*/
(function(n){function l(){}function d(n){return n}function h(n){return typeof n=="function"}function a(n){var i=ri(n),t=0,r;return r={pos:function(){return t},skip:function(n){return t+=n,r},ui8arr:function(n){var t=0,i=[];for(i.length=n;t<n;++t)i[t]=r.ui8();return i},ui8:function(){var n=ui(i,t);return t+=1,n},ui16le:function(){var n=fi(i,t);return t+=2,n},ui32le:function(){var n=ei(i,t);return t+=4,n},ui32be:function(){var n=oi(i,t);return t+=4,n},f64le:function(){var n=si(i,t);return t+=8,n}}}function g(n,t,i){var r=n[0]?ft(a(n[0]),i):{},f=n[1]?bt(a(n[1]),i):{},u=nt(r.shapes||[],f.records||[],t);return u.length?{type:"FeatureCollection",bbox:r.bbox,features:u}:null}function nt(n,t,i){for(var f=[],e=f.length=e=Math.max(n.length,t.length),u,r=0;r<e;++r)u=n[r]||{},f[r]={type:"Feature",geometry:{type:u.gj_type||null,coordinates:u.coordinates?i(u.coordinates):null},properties:t[r]||null};return f}function tt(n){function r(n){return Math.round(n*t)/t}function i(n){return n.map(n[0].length?i:r)}var t=Number("1E"+n);return i}function it(n){return n=n||{},["shp","dbf"].map(function(t){return function(i){n.substr?(t="."+t,hi(n+(n.substr(-t.length).toLowerCase()===t?"":t),function(n,t){i(n,t)})):i(null,n[t]||null)}})}function rt(n,t,i){var r;return ut(it(n),function(n,u){i=h(t)&&t||h(i)&&i||l,t=!h(t)&&t||{};var f=[];n.forEach(function(n){n&&f.push(n)}),r=g(u,t.precision>=0?tt(t.precision):d,f),i(r,f.length?f:null)}),r}function ut(n,t){function e(){--i,i!==0||f||t(r,u)}var r=[],u=[],i=1,f=!0;n.forEach(function(n,t){++i,n(function(n,i){r[t]=n,u[t]=i,e()})}),f=!1,e()}function ft(n,t){var u,f,i,e=[],r;try{u=new Date,i=pt(n)}catch(o){t.push("shp: header parsing error: "+o.message+" / "+o.description);return}i.fileCode!==9994&&t.push("shp: file code: "+i.fileCode+" / expected: 9994"),i.version!==1e3&&t.push("shp: file version: "+i.version+" / expected: 1000");try{while(n.pos()<i.fileLength)if(r=wt(n,i.type,t),r)e.push(r);else break;n.pos()!==i.fileLength&&t.push("shp: file length: "+i.fileLength+" / actual: "+n.pos()),f=new Date}catch(o){t.push("shp: records parsing error: "+o.message+" / "+o.description)}finally{return{bbox:i.bbox_xy,type:i.shapeType,shapes:e,errors:t,time:f-u}}}function et(n,t){t.coordinates=u(n,1)[0]}function v(n,t){var l=e(n),f=i(n),h=i(n),c=o(n,f),a=u(n,h),s=[],r;for(s.length=f,r=0;r<f;++r)s[r]=a.slice(c[r],c[r+1]||h);t.bbox=l,t.coordinates=s}function ot(n,t){t.bbox=e(n),t.coordinates=u(n,i(n))}function st(n,t){t.coordinates=u(n,1)[0],t.coordinates.push(r(n,1)[0])}function ht(n,t){var s=e(n),o=i(n),h=u(n,o),c=f(n),l=r(n,o);t.bbox=s,t.mbox=c,t.coordinates=b(h,l,o)}function y(n,t){var p=e(n),l=i(n),a=i(n),y=o(n,l),w=u(n,a),k=f(n),d=r(n,a),v=[],s,h,c;for(v.length=l,s=0;s<l;++s)h=y[s],c=y[s+1]||a,v[s]=b(w.slice(h,c),d.slice(h,c),c-h);t.bbox=p,t.mbox=k,t.coordinates=v}function ct(n,t){t.coordinates=u(n,1)[0],t.push(r(n,1)[0],r(n,1)[0])}function lt(n,t){var s=e(n),o=i(n),h=u(n,o),l=f(n),a=r(n,o),v=f(n),y=r(n,o);t.bbox=s,t.zbox=l,t.mbox=v,t.coordinates=c(h,a,y,o)}function p(n,t){var w=e(n),v=i(n),a=i(n),p=o(n,v),b=u(n,a),k=f(n),d=r(n,a),g=f(n),nt=r(n,a),y=[],s,h,l;for(y.length=v,s=0;s<v;++s)h=p[s],l=p[s+1]||a,y[s]=c(b.slice(h,l),d.slice(h,l),nt.slice(h,l),l-h);t.bbox=w,t.zbox=k,t.mbox=g,t.coordinates=y}function at(n,t){var w=e(n),a=i(n),v=i(n),p=o(n,a),b=o(n,a),k=u(n,v),d=f(n),g=r(n,v),nt=f(n),tt=r(n,v),y=[],s,h,l;for(y.length=a,s=0;s<a;++s)h=p[s],l=p[s+1]||v,y[s]=c(k.slice(h,l),g.slice(h,l),tt.slice(h,l),l-h);t.bbox=w,t.zbox=d,t.mbox=nt,t.types=b,t.coordinates=y}function pt(n){var t={};return t.fileCode=n.ui32be(),n.skip(20),t.fileLength=n.ui32be()<<1,t.version=n.ui32le(),t.type_number=n.ui32le(),t.type=w[t.type_number],t.bbox_xy=e(n),t.bbox_zm=u(n,2),t}function i(n){return n.ui32le()}function o(n,t){var u=[],r;for(u.length=t,r=0;r<t;++r)u[r]=i(n);return u}function r(n,t){var r=[],i;for(r.length=t,i=0;i<t;++i)r[i]=n.f64le();return r}function e(n){return r(n,4)}function f(n){return[n.f64le(),n.f64le()]}function u(n,t){var r=[],i;for(r.length=t,i=0;i<t;++i)r[i]=f(n);return r}function b(n,t,i){var u=[],r;for(u.length=i,r=0;r<i;++r)u[r]=[n[r][0],n[r][1],t[r]];return u}function c(n,t,i,r){var f=[],u;for(f.length=r,u=0;u<r;++u)f[u]=[n[u][0],n[u][1],t[u],i[u]];return f}function wt(n,t,i){var r={number:n.ui32be()},e=n.ui32be()<<1,u=n.pos(),f=n.ui32le();return r.type_number=f,r.type=w[f],r.gj_type=yt[r.type],r.type?(r.type!==t&&i.push("shp: shape #"+r.number+" type: "+r.type+" / expected: "+t),vt[f](n,r),u=n.pos()-u,u!==e&&i.push("shp: shape #"+r.number+" length: "+e+" / actual: "+u)):(i.push("shp: shape #"+r.number+" type: "+f+" / unknown"),r=null),r}function bt(n,t){var r,u,i,f,e;try{r=new Date,i=kt(n,t),f=ti(i,t),e=ii(n,i.numberOfRecords,i.recordLength,f,t),u=new Date}catch(o){t.push("dbf: parsing error: "+o.message+" / "+o.description)}finally{return{records:e,errors:t,time:u-r}}}function kt(n,t){var i,r={versionNumber:n.ui8(),lastUpdate:new Date(1900+n.ui8(),n.ui8()-1,n.ui8()),numberOfRecords:n.ui32le(),headerLength:n.ui16le(),recordLength:n.ui16le(),fields:[]},u;for(n.skip(20),i=(r.headerLength-n.pos()-1)/32;i>0;--i)r.fields.push(dt(n));return u=n.ui8(),u!==13&&t.push("dbf: header terminator: "+u+" / expected: 13"),r}function s(n,t){return k.apply(null,n.ui8arr(t))}function dt(n){var t={name:s(n,11).replace(/\0*$/gi,""),type:k(n.ui8()),length:n.skip(4).ui8(),count:n.ui8()};return n.skip(14),t}function ni(n,t){return n.skip(t),null}function ti(n,t){for(var e=[],u=0,o=n.fields.length,r,i,f=0,u=0;u<o;++u)i=n.fields[u],r={name:i.name,parser:gt[i.type],length:i.length},r.parser||(r.parser=ni,t.push("dbf: field "+i.name+" type: "+i.type+" / unknown")),f+=i.length,e.push(r);return f+1!==n.recordLength&&t.push("dbf: record length: "+n.recordLength+" / actual: "+(f+1)),e}function ii(n,t,i,r,u){for(var e,l=r.length,f,c=[],h,o,s=0;s<t;++s){for(h={},f=n.pos(),n.skip(1),e=0;e<l;++e)o=r[e],h[o.name]=o.parser(n,o.length);f=n.pos()-f,f!==i&&u.push("dbf: record #"+(s+1)+" length: "+i+" / actual: "+f),c.push(h)}return c}function ri(n){return new DataView(n)}function ui(n,t){return n.getUint8(t)}function fi(n,t){return n.getUint16(t,!0)}function ei(n,t){return n.getUint32(t,!0)}function oi(n,t){return n.getUint32(t,!1)}function si(n,t){return n.getFloat64(t,!0)}function hi(n,t){var i=new XMLHttpRequest;i.onreadystatechange=function(){this.readyState===4&&(this.statusText==="OK"?t(null,this.response):t(this.statusText,null))},i.open("GET",n),i.responseType="arraybuffer",i.setRequestHeader("X-Requested-With","XMLHttpRequest"),i.send(null)}var w={0:"Null",1:"Point",3:"PolyLine",5:"Polygon",8:"MultiPoint",11:"PointZ",13:"PolyLineZ",15:"PolygonZ",18:"MultiPointZ",21:"PointM",23:"PolyLineM",25:"PolygonM",28:"MultiPointM",31:"MultiPatch"},vt={0:l,1:et,3:v,5:v,8:ot,11:ct,13:p,15:p,18:lt,21:st,23:y,25:y,28:ht,31:at},yt={Null:"Null",Point:"Point",PolyLine:"MultiLineString",Polygon:"Polygon",MultiPoint:"MultiPoint",PointZ:"Point",PolyLineZ:"MultiLineString",PolygonZ:"Polygon",MultiPointZ:"MultiPoint",PointM:"Point",PolyLineM:"MultiLineString",PolygonM:"Polygon",MultiPointM:"MultiPoint",MultiPatch:"MultiPatch"},k=String.fromCharCode,gt={C:function(n,t){var i=s(n,t);return i.trim()},N:function(n,t){var i=s(n,t);return parseFloat(i,10)},D:function(n,t){var i=s(n,t);return new Date(i.substring(0,4),i.substring(4,6)-1,i.substring(6,8))}};(function(n){n=n.DevExpress=n.DevExpress||{},n=n.viz=n.viz||{},n.vectormaputils={parse:rt}})(n)})(window);